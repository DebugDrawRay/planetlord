using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planetSatellitesController : MonoBehaviour 
{
	private int minSatelliteCount;
	private int maxSatelliteCount;
	
	private float satelliteMinSpawnDistance;
	private float satelliteMaxSpawnDistance;
	
	private GameObject[] availableSatelliteTypes;
	
	private List<GameObject> childEnemies;

	private Vector3 planetPos;

	void Awake() 
	{
		minSatelliteCount = GetComponent<planetProperties>().minSatelliteCount;
		maxSatelliteCount = GetComponent<planetProperties>().maxSatelliteCount;
				
		satelliteMinSpawnDistance = GetComponent<planetProperties>().satelliteMinSpawnDistance;
		satelliteMaxSpawnDistance = GetComponent<planetProperties>().satelliteMaxSpawnDistance;

		availableSatelliteTypes = GetComponent<planetProperties>().availableSatelliteTypes;

		planetPos = transform.position;

		spawnSatellites();
	}

	void spawnSatellites()
	{
		for(int i = 0; i < Random.Range(minSatelliteCount, maxSatelliteCount); i++)
		{
			GameObject newSatellite;
			newSatellite = Instantiate(availableSatelliteTypes[Random.Range(0, availableSatelliteTypes.Length)],spawnPos(satelliteMinSpawnDistance,satelliteMaxSpawnDistance), Quaternion.identity) as GameObject;
			newSatellite.transform.localScale = new Vector3 (Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
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
