using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boostMeterController : MonoBehaviour 
{
	public string playerShip;
	private float initialFuel;
	void Awake () 
	{
		initialFuel = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().boostFuel;
	}
	
	void Update () 
	{
		GetComponent<Image>().fillAmount = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().boostFuel/initialFuel;
		GetComponent<Image>().color = new Color(1,1,1, (110 - Camera.main.orthographicSize)/100);
		if (GetComponent<Image>().fillAmount < 0.05f)
		{
			GetComponent<Image>().fillAmount = 0.05f;
		}
		
	}
}
