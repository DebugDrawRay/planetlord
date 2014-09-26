using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class miniMapPlayerController : MonoBehaviour 
{

	public string playerShip;
	public GameObject canvasContainer;
	public float depth;
	public float baseWidth;
	public float baseHeight;
	private float miniMapRelDistance;
	private Vector3 playerPos;

	void Awake()
	{
		miniMapRelDistance = canvasContainer.GetComponent<uiController>().miniMapRelDistance;
	}
	void Update () 
	{
		GetComponent<RectTransform>().localScale = new Vector3(1 * (Camera.main.orthographicSize/100),1 * (Camera.main.orthographicSize/100), 1);
		playerPos = GameObject.FindWithTag(playerShip).GetComponent<Transform>().position;
		transform.localPosition = (new Vector3((playerPos.x / miniMapRelDistance) * -1, (playerPos.z / miniMapRelDistance) * -1, depth)) * Camera.main.orthographicSize/100;
	}
}

