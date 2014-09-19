using UnityEngine;
using System.Collections;

public class smallMineController : MonoBehaviour 
{
	private float despawnTimer;

	void Start () 
	{
		despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
	}

	void Update () 
	{
		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
