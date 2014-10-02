using UnityEngine;
using System.Collections;

public class gunshipCarrierController : MonoBehaviour 
{
	private float pursuitRange;
	
	private GameObject parentObject;
	private Vector3 targetPos;
	private Vector3 targetVector;
	private float targetDistance;
	
	private float correctionBoostTimer;
	
	private float acceleration;
	private float slowDistance;
	private float initialDrag;
	private float dragMultiplier;
	private float correctionBoostMulti;
	
	private float currentFireDelay;
	private float initialFireDelay;

	private string[] damagedBy;
	private float armorCount;
	
	void Awake ()
	{
		damagedBy = GetComponent<carrierProperties>().damagedBy;
		armorCount = GetComponent<carrierProperties>().armorCount;

		pursuitRange = GetComponent<carrierProperties>().pursuitRange;
		
		acceleration = GetComponent<carrierProperties>().acceleration;
		slowDistance = GetComponent<carrierProperties>().slowDistance;
		
		initialDrag = GetComponent<carrierProperties>().initialDrag;
		dragMultiplier = GetComponent<carrierProperties>().dragMultiplier;
		rigidbody.drag = initialDrag;
		
		correctionBoostTimer = GetComponent<carrierProperties>().correctionBoostTimer;
		correctionBoostMulti = GetComponent<carrierProperties>().correctionBoostMulti;
		
		parentObject = GetComponent<carrierProperties>().parentObject;

	}
	
	void Update()
	{
		parentObject = GetComponent<carrierProperties>().parentObject;

		GetComponent<carrierProperties>().armorCount = armorCount;
		
		stateController();
		targetTracking();
		lookAtTarget();
	}
	
	void targetTracking()
	{
		targetDistance = Vector3.Distance (transform.position, targetPos);
		targetPos = parentObject.transform.position;
		targetVector = targetPos - transform.position;
	}

	void lookAtTarget()
	{
		transform.LookAt(new Vector3(targetPos.x, 0, targetPos.z));
	}
	
	void stateController()
	{
			engineDirectionController();
	}
	
	void engineDirectionController()
	{
		fireEngines(transform.right, correctionBoostTimer);

		if (targetDistance < pursuitRange)
		{
			fireEngines(-transform.forward, correctionBoostTimer);
		}
		else
		{
			fireEngines(transform.forward, correctionBoostTimer);
		}
	}
	
	void fireEngines(Vector3 direction, float correctionCount)
	{
		correctionCount -= 1;
		
		rigidbody.drag = dragController(initialDrag);
		if (correctionCount > 0)
		{
			rigidbody.AddForce((direction * acceleration) * correctionBoostMulti);
		}
		else
		{
			rigidbody.AddForce((direction * acceleration));
		}
	}
	
	float dragController(float dragVal)
	{
		float dragSet;
		if (targetDistance <= slowDistance)
		{
			dragSet = dragVal + ((1/targetDistance) * slowDistance);
			return dragSet;
		}
		else
		{
			dragSet = dragVal * (rigidbody.velocity.magnitude * dragMultiplier);
			return dragSet;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		foreach(string tag in damagedBy)
		{
			if(other.gameObject.tag == tag)
			{
				dealDamage(other.gameObject.GetComponent<equipmentProperties>().baseDamage);
				Destroy(other.gameObject);
			}
		}
	}
	
	void dealDamage(float damageValue)
	{
		armorCount -= damageValue;
	}
}
