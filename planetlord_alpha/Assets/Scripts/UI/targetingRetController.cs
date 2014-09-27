using UnityEngine;
using System.Collections;

public class targetingRetController : MonoBehaviour 
{
	private Vector3 mousePos;
	void Update () 
	{
		GetComponent<SpriteRenderer>().enabled = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().targetingCur;

		mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(mousePos.x, 0, mousePos.z);

	}
}
