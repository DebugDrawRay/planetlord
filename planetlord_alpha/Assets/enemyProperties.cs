using UnityEngine;
using System.Collections;

public class enemyProperties : MonoBehaviour 
{
	public float armorCount;

	public bool isDead;

	public float pursuitRange;
	public float combatRange;
	
	public float acceleration;
	public float slowDistance;
	public float initialDrag;
	public float dragMultiplier;
	public float correctionBoostTimer;
	public float correctionBoostMulti;

	public string[] damagedBy;

	public string attackTargetTag;

	public GameObject attackTarget;
	public GameObject equippedWeapon;

	void Update()
	{
		attackTarget = GameObject.FindGameObjectWithTag(attackTargetTag);
		statusController();
	}

	void statusController()
	{
		if (armorCount <= 0)
		{
			destroyThis();
		}
	}

	void destroyThis()
	{
		Destroy(this.gameObject);
		isDead = true;
	}
}
