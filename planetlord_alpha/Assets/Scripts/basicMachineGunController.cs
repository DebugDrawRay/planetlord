using UnityEngine;
using System.Collections;

public class basicMachineGunController : MonoBehaviour 
{
	private float despawnTimer;

	void Start () 
	{
		rigidbody.velocity = (transform.forward * GetComponent<equipmentProperties>().baseSpeed);
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
