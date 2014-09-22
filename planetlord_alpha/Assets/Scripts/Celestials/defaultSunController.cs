using UnityEngine;
using System.Collections;

public class defaultSunController : MonoBehaviour 
{
	void Awake()
	{
		transform.position += new Vector3 (0, GetComponent<sunProperties>().floatOffset, 0);
	}
}
