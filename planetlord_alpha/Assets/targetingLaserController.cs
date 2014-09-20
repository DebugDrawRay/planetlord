using UnityEngine;
using System.Collections;

public class targetingLaserController : MonoBehaviour 
{
	void Update () 
	{
		GetComponent<LineRenderer>().SetPosition(0, GameObject.FindGameObjectWithTag("Player").transform.position);
	//}
	//void FixedUpdate()
	//{
		GetComponent<LineRenderer>().SetPosition(1, new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z));
	}
}
