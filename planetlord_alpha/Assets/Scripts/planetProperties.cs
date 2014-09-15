using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planetProperties : MonoBehaviour 
{
	public int minEnemyCount;
	public int maxEnemyCount;

	public float enemyMinSpawnDistance;
	public float enemyMaxSpawnDistance;

	public float floatOffset;

	public string playerShip;

	public string inGameUI;

	public GameObject planetInteractionMenu;

	public GameObject[] availableEnemyTypes;

	public List<GameObject> childEnemies;

	public bool isCaptured;
}
