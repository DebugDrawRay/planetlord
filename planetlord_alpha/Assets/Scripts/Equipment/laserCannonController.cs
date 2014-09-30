using UnityEngine;
using System.Collections;

public class laserCannonController : MonoBehaviour 
{
	private float baseSpeed;
	private float maxBeamLength;
	private float beamLengthIncrease;
	private float despawnTimer;
	private GameObject equipmentOwner;

	void Awake()
	{
		equipmentOwner = GetComponent<equipmentProperties>().equipmentOwner;
		baseSpeed = GetComponent<equipmentProperties>().baseSpeed;
		maxBeamLength = GetComponent<equipmentProperties>().maxBeamLength;
		beamLengthIncrease = GetComponent<equipmentProperties>().beamLengthIncrease;
		rigidbody.velocity = (transform.forward * (baseSpeed + equipmentOwner.rigidbody.velocity.magnitude));
		despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
	}
	void FixedUpdate()
	{
		if (transform.localScale.y < maxBeamLength)
		{
			transform.localScale += new Vector3(0,0,beamLengthIncrease);
		}

		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
