using UnityEngine;
using System.Collections;

public class machineGunTurret : MonoBehaviour 
{
	private GameObject ammoType;
	private float activeRange;
	private float minRotAngle;
	private float maxRotAngle;
	private float initialFireDelay;
	private float currentFireDelay;
	private string targetTag;


	void Awake()
	{
		ammoType = GetComponent<turretProperties>().ammoType;
		activeRange = GetComponent<turretProperties>().activeRange;
		minRotAngle = GetComponent<turretProperties>().minRotAngle;
		maxRotAngle = GetComponent<turretProperties>().maxRotAngle;
		targetTag = GetComponent<turretProperties>().targetTag;
		initialFireDelay = ammoType.GetComponent<equipmentProperties>().weaponFireDelay;
		currentFireDelay = initialFireDelay;
	}

	void Update()
	{
		currentFireDelay -= Time.deltaTime;

		if (GameObject.FindGameObjectWithTag(targetTag).transform.position.x > transform.position.x )
		{
			float angle;
			angle = Vector3.Angle(GameObject.FindGameObjectWithTag(targetTag).transform.position - GetComponentInChildren<Transform>().position, GetComponentInChildren<Transform>().position);
			Debug.Log (angle);
			if(angle > minRotAngle && angle < maxRotAngle)
			{
				transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag(targetTag).transform.position.x, 0, GameObject.FindGameObjectWithTag(targetTag).transform.position.z));
				
				if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag(targetTag).transform.position) <= activeRange)
				{
					fireWeapon();
				}
			}
		}
		else
		{
			float angle;
			angle = 360 - Vector3.Angle(GameObject.FindGameObjectWithTag(targetTag).transform.position - GetComponentInChildren<Transform>().position, GetComponentInChildren<Transform>().position);
			Debug.Log (angle);
			if(angle > minRotAngle && angle < maxRotAngle)
			{
				transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag(targetTag).transform.position.x, 0, GameObject.FindGameObjectWithTag(targetTag).transform.position.z));
				
				if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag(targetTag).transform.position) <= activeRange)
				{
					fireWeapon();
				}
			}
		}

	}

	void fireWeapon()
	{
		if (currentFireDelay <= 0) 
		{
			currentFireDelay = initialFireDelay;
			Instantiate(ammoType, transform.position, transform.rotation);
		}
	}
}
