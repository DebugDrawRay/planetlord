using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Trigger");
		if(other.gameObject.tag == "Player")
		{
			Debug.Log ("Trigger");
		}
	}

}
