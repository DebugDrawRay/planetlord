using UnityEngine;
using System.Collections;

public class basicMachineGunController : MonoBehaviour 
{
	private float despawnTimer;
	private string equipmentOwner;

	void Start () 
	{
		equipmentOwner = GetComponent<equipmentProperties>().equipmentOwner;
		rigidbody.velocity = (transform.forward * (GetComponent<equipmentProperties>().baseSpeed + GameObject.FindGameObjectWithTag(equipmentOwner).rigidbody.velocity.magnitude));
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
