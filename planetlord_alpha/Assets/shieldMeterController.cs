using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class shieldMeterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Image>().color = new Color(1,1,1, (110 - Camera.main.orthographicSize)/100);
	}
}
