using UnityEngine;
using System.Collections;

public class visionController : MonoBehaviour 
{
	public string[] lookingFor;
	public bool inVision;

	void OnTriggerStay(Collider other)
	{
		foreach(string obj in lookingFor)
		{
			if (other.gameObject.tag == obj)
			{
				inVision = true;
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		foreach(string obj in lookingFor)
		{
			if (other.gameObject.tag == obj)
			{
				inVision = false;
			}
		}
	}
}
