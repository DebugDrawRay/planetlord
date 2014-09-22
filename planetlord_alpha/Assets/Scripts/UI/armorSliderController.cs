using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class armorSliderController : MonoBehaviour 
{
	public string playerShip;

	void Awake () 
	{
		GetComponent<Slider>().minValue = 0;
		GetComponent<Slider>().maxValue = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().armorValue;
	}
	
	void Update () 
	{
		GetComponent<Slider>().value = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().armorValue;
	}
}
