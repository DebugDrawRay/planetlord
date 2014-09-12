using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour 
{
	public GameObject playerShip;

	private float yVal;

	void Awake()
	{
		yVal = transform.position.y;
	}

	void Update () 
	{
		followPlayer();
	}

	void followPlayer()
	{
		transform.position = new Vector3(playerShip.transform.position.x, yVal, playerShip.transform.position.z);
	}
}
