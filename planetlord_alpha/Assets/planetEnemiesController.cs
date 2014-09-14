using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planetEnemiesController : MonoBehaviour 
{
	private int minEnemyCount;
	private int maxEnemyCount;
	
	private float enemyMinSpawnDistance;
	private float enemyMaxSpawnDistance;
	
	private float floatOffset;
	
	private GameObject[] availableEnemyTypes;
	
	private List<GameObject> childEnemies;
	
	private bool isCaptured;

	private Vector3 planetPos;

	void Awake() 
	{
		minEnemyCount = GetComponent<planetProperties>().minEnemyCount;
		maxEnemyCount = GetComponent<planetProperties>().maxEnemyCount;
				
		enemyMinSpawnDistance = GetComponent<planetProperties>().enemyMinSpawnDistance;
		enemyMaxSpawnDistance = GetComponent<planetProperties>().enemyMaxSpawnDistance;

		availableEnemyTypes = GetComponent<planetProperties>().availableEnemyTypes;

		planetPos = transform.position;

		childEnemies = GetComponent<planetProperties>().childEnemies;
		spawnEnemies();
	}

	void Update()
	{
		GetComponent<planetProperties>().childEnemies = childEnemies;
	}

	void spawnEnemies()
	{
		for(int i = 0; i < Random.Range(minEnemyCount, maxEnemyCount); i++)
		{
			GameObject newEnemy;
			newEnemy = Instantiate(availableEnemyTypes[Random.Range(0, availableEnemyTypes.Length)],spawnPos(enemyMinSpawnDistance,enemyMaxSpawnDistance), Quaternion.identity) as GameObject;
			childEnemies.Add(newEnemy);
		}
	}

	Vector3 spawnPos(float min, float max) 
	{	
		Vector3 pos = new Vector3(Random.Range(planetPos.x-max,planetPos.x+max), 0, Random.Range(planetPos.z-max,planetPos.z+max));
		for (int i = 0; i < 1000; i++)
		{
			pos = new Vector3(Random.Range(planetPos.x-max,planetPos.x+max), 0, Random.Range(planetPos.z-max,planetPos.z+max));
			if (Vector3.Distance(planetPos, pos) >= min)
			{
				i = 1000;
				return pos;
			}
			else
			{
				continue;
			}
		}
		return pos;
	}
}
