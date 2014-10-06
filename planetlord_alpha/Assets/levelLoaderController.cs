using UnityEngine;
using System.Collections;

public class levelLoaderController : MonoBehaviour 
{
	void Start () 
	{
		Application.LoadLevel("mainScene");
	}
}
