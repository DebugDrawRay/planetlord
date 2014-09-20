using UnityEngine;
using System.Collections;

public class targetingRetController : MonoBehaviour 
{
	void Update () 
	{
		transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
		//transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
