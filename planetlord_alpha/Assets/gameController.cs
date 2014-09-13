using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour 
{
	//solar system variables

	public GameObject[] availableSuns;
	public GameObject[] availablePlanets;

	public int maxPlanetsInSystem;
	public int minPlanetsInSystem;

	public float minPlanetSpacing;
	public float maxPlanetSpacing;
	public float minDistanceFromSun;

	public float lastSpawnDistance;

	private Vector3 sunPos;

	private bool firstPlanetCreated;

	void Awake()
	{
		sunPos = Vector3.zero;
		solarSystemGenerationController();
	}

	//generate the solar system

	void solarSystemGenerationController()
	{
		createSun();
	}

	void createSun()
	{
		Instantiate (availableSuns[Random.Range(0, availableSuns.Length)], sunPos, Quaternion.identity);
		createPlanets();
	}
	
	void createPlanets()
	{
		for (int i = 0; i < Random.Range(minPlanetsInSystem, maxPlanetsInSystem); i++)
		{
			if (firstPlanetCreated == false)
			{
				firstPlanetCreated = true;
				lastSpawnDistance = minDistanceFromSun;
				Instantiate (availablePlanets[Random.Range(0, availablePlanets.Length)], objectPosition(lastSpawnDistance, maxPlanetSpacing, sunPos), Quaternion.identity);

			}
			else
			{
				Instantiate (availablePlanets[Random.Range(0, availablePlanets.Length)], objectPosition(minPlanetSpacing, maxPlanetSpacing, sunPos), Quaternion.identity);
			}
		}
	}

	Vector3 objectPosition(float min, float max, Vector3 sunPos)
	{
		Vector3 pos = new Vector3(Random.Range(-(lastSpawnDistance + max),lastSpawnDistance + max),0,Random.Range(-(lastSpawnDistance + max),lastSpawnDistance + max));
		for (int i = 0; i < 1000; i++)
		{
			pos = new Vector3(Random.Range(-(lastSpawnDistance + max),lastSpawnDistance + max),0,Random.Range(-(lastSpawnDistance + max),lastSpawnDistance + max));
			if (Vector3.Distance(sunPos, pos) >= lastSpawnDistance)
			{
				lastSpawnDistance = Vector3.Distance(sunPos, pos) + min;
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
