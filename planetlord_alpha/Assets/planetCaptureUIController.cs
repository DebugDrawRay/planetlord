using UnityEngine;
using System.Collections;

public class planetCaptureUIController : MonoBehaviour 
{
	public GameObject outlineGraphic;
	public GameObject captureLogo;

	void Update()
	{
		outlineGraphic.GetComponent<SpriteRenderer>().enabled = transform.parent.GetComponent<planetProperties>().isCaptured;
		captureLogo.GetComponent<SpriteRenderer>().enabled = transform.parent.GetComponent<planetProperties>().isCaptured;
	}
}
