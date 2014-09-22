using UnityEngine;
using System.Collections;

public class machineGunTurret : MonoBehaviour 
{
	private GameObject ammoType;
	private float activeRange;
	private float rotationAngle;
	private float initialFireDelay;
	private float currentFireDelay;
	private string targetTag;


	void Awake()
	{
		ammoType = GetComponent<turretProperties>().ammoType;
		activeRange = GetComponent<turretProperties>().activeRange;
		rotationAngle = GetComponent<turretProperties>().rotationAngle;
		targetTag = GetComponent<turretProperties>().targetTag;
		initialFireDelay = ammoType.GetComponent<equipmentProperties>().weaponFireDelay;
		currentFireDelay = initialFireDelay;
	}

	void Update()
	{
		currentFireDelay -= Time.deltaTime;

		float angle;
		angle = Vector3.Angle(GameObject.FindGameObjectWithTag(targetTag).transform.position - transform.position, GetComponentInChildren<Transform>().position);

		if(angle < rotationAngle/2)
		{
			transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag(targetTag).transform.position.x, 0, GameObject.FindGameObjectWithTag(targetTag).transform.position.z));

			if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag(targetTag).transform.position) <= activeRange)
			{
				fireWeapon();
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
