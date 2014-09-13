using UnityEngine;
using System.Collections;

public class droneController: MonoBehaviour 
{
	private float pursuitRange;
	private float combatRange;

	private GameObject attackTarget;
	private Vector3 targetPos;
	private Vector3 targetVector;
	private float targetDistance;

	private Vector3 westEngine;
	private Vector3 eastEngine;
	private Vector3 southEngine;
	private Vector3 northEngine;

	private float correctionBoostTimer;

	private float acceleration;
	private float slowDistance;
	private float initialDrag;
	private float dragMultiplier;
	private float correctionBoostMulti;

	private float currentFireDelay;
	private float initialFireDelay;
	private GameObject equippedWeapon;

	void Awake ()
	{
		pursuitRange = GetComponent<enemyProperties>().pursuitRange;
		combatRange = GetComponent<enemyProperties>().combatRange;
		
		acceleration = GetComponent<enemyProperties>().acceleration;
		slowDistance = GetComponent<enemyProperties>().slowDistance;

		initialDrag = GetComponent<enemyProperties>().initialDrag;
		dragMultiplier = GetComponent<enemyProperties>().dragMultiplier;
		rigidbody.drag = initialDrag;

		correctionBoostTimer = GetComponent<enemyProperties>().correctionBoostTimer;
		correctionBoostMulti = GetComponent<enemyProperties>().correctionBoostMulti;
		
		attackTarget = GetComponent<enemyProperties>().attackTarget;

		equippedWeapon = GetComponent<enemyProperties>().equippedWeapon;
		initialFireDelay = equippedWeapon.GetComponent<projectileProperties>().weaponFireDelay;
		currentFireDelay = initialFireDelay;

		//initialize engines
		westEngine = new Vector3(1,0,0);
		eastEngine = new Vector3(-1,0,0);
		northEngine = new Vector3(0,0,-1);
		southEngine = new Vector3(0,0,1);
	}

	void Update()
	{
		stateController();
		targetTracking();
		lookAtTarget();
	}

	void targetTracking()
	{
		targetDistance = Vector3.Distance (transform.position, targetPos);
		targetPos = attackTarget.transform.position;
		targetVector = targetPos - transform.position;
	}

	void stateController()
	{
		if (targetDistance <= pursuitRange && targetDistance > slowDistance) 
		{
			engineDirectionController();
		}

		if (targetDistance <= combatRange)
		{
			combatController();
		}
	}

	void engineDirectionController()
	{
		if (targetVector.x > 0) 
		{
			fireEngines(westEngine, correctionBoostTimer);
		}
		if (targetVector.x <= 0) 
		{
			fireEngines(eastEngine, correctionBoostTimer);
		}
		if (targetVector.z > 0) 
		{
			fireEngines(southEngine, correctionBoostTimer);
		}
		if (targetVector.z <= 0) 
		{
			fireEngines(northEngine, correctionBoostTimer);
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

	void lookAtTarget()
	{
		transform.LookAt(targetPos);
	}

	void combatController()
	{
		currentFireDelay -= Time.deltaTime;
		fireWeapon();
	}

	void fireWeapon()
	{
		if (currentFireDelay <= 0) 
		{
			currentFireDelay = initialFireDelay;
			Instantiate (equippedWeapon, transform.position, transform.rotation);
		}
	}

}
