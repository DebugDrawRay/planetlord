using UnityEngine;
using System.Collections;

public class basicMachineGunController : MonoBehaviour 
{
	private float despawnTimer;
	private GameObject equipmentOwner;

	void Start () 
	{
		equipmentOwner = GetComponent<equipmentProperties>().equipmentOwner;
		rigidbody.velocity = (transform.forward * (GetComponent<equipmentProperties>().baseSpeed + equipmentOwner.rigidbody.velocity.magnitude));
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
