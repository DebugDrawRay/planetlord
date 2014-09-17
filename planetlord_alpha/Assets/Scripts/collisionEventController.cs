using UnityEngine;
using System.Collections;

public class collisionEventController : MonoBehaviour 
{
	private string[] damagedBy;

	private float armorCount;

	void Awake()
	{
		damagedBy = GetComponent<enemyProperties>().damagedBy;
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
	}

	void dealDamage(float damageValue)
	{
		armorCount -= damageValue;
	}
}
