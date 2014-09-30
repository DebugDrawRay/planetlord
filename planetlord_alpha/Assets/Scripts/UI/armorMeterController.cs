using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class armorMeterController : MonoBehaviour 
{
	public string playerShip;
	public float baseOpacity;
	private float initialArmor;
	void Start()
	{
		initialArmor = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().armorValue;
	}
	void Update () 
	{
		GetComponent<Image>().fillAmount = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().armorValue/initialArmor;
		GetComponent<Image>().color = new Color(1,1,1, (110 - Camera.main.orthographicSize)/100);
	}
}
