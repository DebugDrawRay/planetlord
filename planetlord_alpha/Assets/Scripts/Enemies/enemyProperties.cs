using UnityEngine;
using System.Collections;

public class enemyProperties : MonoBehaviour 
{
	public float armorCount;

	public bool isDead;
	public float id;

	public float pursuitRange;
	public float combatRange;
	
	public float acceleration;
	public float slowDistance;
	public float initialDrag;
	public float dragMultiplier;
	public float correctionBoostTimer;
	public float correctionBoostMulti;

	public string[] damagedBy;
	public string[] repelledBy;

	public GameObject[] itemsDropped;

	public string attackTargetTag;

	public GameObject attackTarget;
	public GameObject equippedWeapon;
	public GameObject parentObject;


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
			dropItems();
		}
	}

	void destroyThis()
	{
		for (int i = 0; i <= GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().trackableTargets.Count -1; i++)
		{
			if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().trackableTargets[i].gameObject.tag == "Enemy")
			{
				if (GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().trackableTargets[i].GetComponent<enemyProperties>().id == id)
				{
					GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().trackableTargets.RemoveAt(i);
				}
			}
		}
		Destroy(this.gameObject);
		isDead = true;
	}

	void dropItems()
	{
		foreach (GameObject item in itemsDropped)
		{
			Instantiate(item, transform.position, Quaternion.identity);
		}
	}
}
