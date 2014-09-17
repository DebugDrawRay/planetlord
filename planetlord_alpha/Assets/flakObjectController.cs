using UnityEngine;
using System.Collections;

public class flakObjectController : MonoBehaviour 
{
	public float despawnTimer;

	void Update () 
	{
		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
