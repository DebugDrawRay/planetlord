using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planetProperties : MonoBehaviour 
{
	public int minEnemyCount;
	public int maxEnemyCount;

	public float enemyMinSpawnDistance;
	public float enemyMaxSpawnDistance;

	public int minSatelliteCount;
	public int maxSatelliteCount;

	public float satelliteMinSpawnDistance;
	public float satelliteMaxSpawnDistance;

	public float floatOffset;

	public string playerShip;
	public string inGameUI;
	public string gameController;

	public GameObject[] availableEnemyTypes;
	public GameObject[] availableSatelliteTypes;
	public List<GameObject> planetInventory;

	public List<GameObject> childEnemies;

	public bool isCaptured;
}
