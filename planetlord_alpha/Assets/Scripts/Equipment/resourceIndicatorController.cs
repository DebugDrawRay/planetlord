using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class resourceIndicatorController : MonoBehaviour 
{
	public string playerShip;

	void Update () 
	{
		GetComponent<Text>().text = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().resourcesCollected + ""; 		
	}
}
