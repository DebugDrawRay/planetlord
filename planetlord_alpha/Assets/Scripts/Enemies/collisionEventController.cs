using UnityEngine;
using System.Collections;

public class collisionEventController : MonoBehaviour 
{
	private string[] damagedBy;
	private string[] repelledBy;
	private float armorCount;

	void Awake()
	{
		damagedBy = GetComponent<enemyProperties>().damagedBy;
		repelledBy = GetComponent<enemyProperties>().repelledBy;
		armorCount = GetComponent<enemyProperties>().armorCount;
	}

	void Update()
	{
		GetComponent<enemyProperties>().armorCount = armorCount;
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

		foreach(string tag in repelledBy)
		{
			if(other.gameObject.tag == tag)
			{
				dealDamage(other.gameObject.GetComponent<equipmentProperties>().baseDamage);
			}
		}
	}

	void dealDamage(float damageValue)
	{
		armorCount -= damageValue;
	}
}
