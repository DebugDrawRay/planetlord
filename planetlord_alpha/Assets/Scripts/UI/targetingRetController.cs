using UnityEngine;
using System.Collections;

public class targetingRetController : MonoBehaviour 
{
	void Update () 
	{
		GetComponent<SpriteRenderer>().enabled = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().targetingCur;
		transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 20, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
		//transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
