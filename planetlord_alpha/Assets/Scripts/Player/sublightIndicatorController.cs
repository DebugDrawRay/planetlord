using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sublightIndicatorController : MonoBehaviour 
{
	public string playerShip;
	
	void Update () 
	{
		GetComponent<Text>().enabled = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().subLightDrive;
	}
}
