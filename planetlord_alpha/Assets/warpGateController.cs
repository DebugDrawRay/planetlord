using UnityEngine;
using System.Collections;

public class warpGateController : MonoBehaviour 
{
	public string gameController;
	public float floatOffset;
	public string playerShip;
	public string transitionLevel;

	void Awake()
	{
		transform.position += new Vector3(0,floatOffset,0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == playerShip)
		{
			Debug.Log ("player");
			if (GameObject.FindGameObjectWithTag(gameController).GetComponent<gameController>().systemConquered)
			{
				Debug.Log ("conqured");
				activateWarp();
			}
		}
	}

	void activateWarp()
	{
		Application.LoadLevel(transitionLevel);
	}

}
