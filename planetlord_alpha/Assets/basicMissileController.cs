using UnityEngine;
using System.Collections;

public class basicMissileController : MonoBehaviour 
{
	private float despawnTimer;
	private string equipmentOwner;
	
	void Start () 
	{
		equipmentOwner = GetComponent<equipmentProperties>().equipmentOwner;
		//rigidbody.velocity = (transform.forward * (GetComponent<equipmentProperties>().baseSpeed + GameObject.FindGameObjectWithTag(equipmentOwner).rigidbody.velocity.magnitude));
		despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
	}
	
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag(equipmentOwner).GetComponent<playerController>().currentTrackedTarget != null)
		{
			transform.LookAt(GameObject.FindGameObjectWithTag(equipmentOwner).GetComponent<playerController>().currentTrackedTarget.transform.position);
		}
		rigidbody.velocity = (transform.forward * (GetComponent<equipmentProperties>().baseSpeed + GameObject.FindGameObjectWithTag(equipmentOwner).rigidbody.velocity.magnitude));

		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
