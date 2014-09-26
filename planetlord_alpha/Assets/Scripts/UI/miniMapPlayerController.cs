using UnityEngine;
using System.Collections;

public class miniMapPlayerController : MonoBehaviour 
{

	public string playerShip;
	public GameObject canvasContainer;
	public float depth;
	private float miniMapRelDistance;
	private Vector3 playerPos;

	void Awake()
	{
		miniMapRelDistance = canvasContainer.GetComponent<uiController>().miniMapRelDistance;
	}
	void Update () 
	{
		playerPos = GameObject.FindWithTag(playerShip).GetComponent<Transform>().position;
		transform.localPosition = new Vector3((playerPos.x / miniMapRelDistance) * -1, (playerPos.z / miniMapRelDistance) * -1, depth);
	}
}
