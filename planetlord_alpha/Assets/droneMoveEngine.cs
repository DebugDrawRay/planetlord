using UnityEngine;
using System.Collections;

public class droneMoveEngine : MonoBehaviour 
{
	public float pursuitRange;
	public float combatRange;

	public GameObject attackTarget;
	private Vector3 targetPos;
	private Vector3 targetVector;
	private float targetDistance;

	private Vector3 westEngine;
	private Vector3 eastEngine;
	private Vector3 southEngine;
	private Vector3 northEngine;

	public float correctionTimer;

	public float acceleration;
	public float slowDistance;
	public float initialDrag;
	public float dragMultiplier;
	public float correctionBoostMulti;

	void Awake ()
	{
		//initialize values
		rigidbody.drag = initialDrag;
		//currentDelay = delay;
		westEngine = new Vector3(1,0,0);
		eastEngine = new Vector3(-1,0,0);
		northEngine = new Vector3(0,0,-1);
		southEngine = new Vector3(0,0,1);
	}

	void Update()
	{
		stateController();
		targetTracking();
	}

	void targetTracking()
	{
		targetDistance = Vector3.Distance (transform.position, targetPos);
		targetPos = attackTarget.transform.position;
		targetVector = targetPos - transform.position;
	}

	void stateController()
	{
		if (targetDistance <= pursuitRange && targetDistance > combatRange) 
		{
			engineDirectionController();
		}
		else if (targetDistance <= combatRange)
		{
			//combatControler();
		}
	}

	void engineDirectionController()
	{
		if (targetVector.x > 0) 
		{
			fireEngines(westEngine, correctionTimer);
		}
		if (targetVector.x <= 0) 
		{
			fireEngines(eastEngine, correctionTimer);
		}
		if (targetVector.z > 0) 
		{
			fireEngines(southEngine, correctionTimer);
		}
		if (targetVector.z <= 0) 
		{
			fireEngines(northEngine, correctionTimer);
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
}
