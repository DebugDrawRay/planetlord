using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class shieldMeterController : MonoBehaviour 
{
	public string playerShip;
	public float baseOpacity;
	private float initialShield;

	void Start()
	{
		initialShield = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().shieldValue;
	}
	void Update () 
	{
		GetComponent<Image>().fillAmount = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().shieldValue / initialShield;
		GetComponent<Image>().color = new Color(1,1,1, (110 - Camera.main.orthographicSize)/100);

		if (GetComponent<Image>().fillAmount < 0.05f)
		{
			GetComponent<Image>().fillAmount = 0.05f;
		}
	}
}
