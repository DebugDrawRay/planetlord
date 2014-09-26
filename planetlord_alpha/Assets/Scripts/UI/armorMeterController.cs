using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class armorMeterController : MonoBehaviour 
{
	public string playerShip;
	private float initialArmor;
	void Awake()
	{
		initialArmor = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().armorValue;
	}
	void Update () 
	{
		GetComponent<Image>().fillAmount = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().armorValue/initialArmor;
	}
}
