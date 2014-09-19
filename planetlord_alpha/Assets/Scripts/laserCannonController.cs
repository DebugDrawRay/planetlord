using UnityEngine;
using System.Collections;

public class laserCannonController : MonoBehaviour 
{
	private float baseSpeed;
	private float maxBeamLength;
	private float beamLengthIncrease;
	private float despawnTimer;

	void Awake()
	{
		baseSpeed = GetComponent<equipmentProperties>().baseSpeed;
		maxBeamLength = GetComponent<equipmentProperties>().maxBeamLength;
		beamLengthIncrease = GetComponent<equipmentProperties>().beamLengthIncrease;
		rigidbody.velocity = (transform.forward * baseSpeed);
		despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
	}
	void Update()
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
