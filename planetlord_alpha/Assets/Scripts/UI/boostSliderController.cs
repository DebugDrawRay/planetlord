using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boostSliderController : MonoBehaviour 
{
	public string playerShip;

	void Awake () 
	{
		GetComponent<Slider>().minValue = 0;
		GetComponent<Slider>().maxValue = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().boostFuel;
	}
	
	void Update () 
	{
		GetComponent<Slider>().value = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().boostFuel;
	}
}
