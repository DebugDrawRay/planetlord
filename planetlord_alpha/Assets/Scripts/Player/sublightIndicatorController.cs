using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sublightIndicatorController : MonoBehaviour 
{
	public string playerShip;
	
	void Update () 
	{
		GetComponent<Image>().enabled = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().subLightDrive;
		GetComponent<Image>().color = new Color(1,1,1, (110 - Camera.main.orthographicSize)/100);
	}
}
