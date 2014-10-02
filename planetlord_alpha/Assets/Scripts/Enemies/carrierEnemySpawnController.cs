using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class carrierEnemySpawnController : MonoBehaviour 
{
	private int minEnemyCount;
	private int maxEnemyCount;
	
	private float enemyMinSpawnDistance;
	private float enemyMaxSpawnDistance;
	
	private float floatOffset;
	
	private GameObject[] availableEnemyTypes;
	
	private List<GameObject> childEnemies;
	
	private bool isCaptured;
	
	private Vector3 originPos;
	
	private Component propertiesScript;
	
	void Awake() 
	{
		minEnemyCount = GetComponent<carrierProperties>().minEnemyCount;
		maxEnemyCount = GetComponent<carrierProperties>().maxEnemyCount;
		
		enemyMinSpawnDistance = GetComponent<carrierProperties>().enemyMinSpawnDistance;
		enemyMaxSpawnDistance = GetComponent<carrierProperties>().enemyMaxSpawnDistance;
		
		availableEnemyTypes = GetComponent<carrierProperties>().availableEnemyTypes;
		
		originPos = transform.position;
		
		childEnemies = GetComponent<carrierProperties>().childEnemies;
		spawnEnemies();
	}
	
	void Update()
	{
		GetComponent<carrierProperties>().childEnemies = childEnemies;
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
		Vector3 pos = new Vector3(Random.Range(originPos.x-max,originPos.x+max), 0, Random.Range(originPos.z-max,originPos.z+max));
		for (int i = 0; i < 1000; i++)
		{
			pos = new Vector3(Random.Range(originPos.x-max,originPos.x+max), 0, Random.Range(originPos.z-max,originPos.z+max));
			if (Vector3.Distance(originPos, pos) >= min)
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
