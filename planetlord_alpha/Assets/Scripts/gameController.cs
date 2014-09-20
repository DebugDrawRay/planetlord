using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameController : MonoBehaviour 
{
	//solar system variables

	public GameObject[] availableSuns;
	public GameObject[] availablePlanets;

	public List<GameObject> solarSystemObjects;
	public List<GameObject> trackableTargets;

	public int maxPlanetsInSystem;
	public int minPlanetsInSystem;

	public float minPlanetSpacing;
	public float maxPlanetSpacing;
	public float minDistanceFromSun;

	public float lastSpawnDistance;
	
	public bool globalPause;

	private Vector3 sunPos;

	private bool firstPlanetCreated;

	void Awake()
	{
		//Screen.showCursor = false;

		sunPos = Vector3.zero;
		solarSystemGenerationController();
	}

	void Update()
	{
		lockCursor();
	}

	void lockCursor()
	{
		Rect screenRect = new Rect(0,0, Screen.width, Screen.height);
		if (!screenRect.Contains(Input.mousePosition))
			return;
	}

	//generate the solar system

	void solarSystemGenerationController()
	{
		createSun();
	}

	void createSun()
	{
		GameObject sun;
		sun = Instantiate (availableSuns[Random.Range(0, availableSuns.Length)], sunPos, Quaternion.identity) as GameObject;
		solarSystemObjects.Add(sun);
		createPlanets();
	}
	
	void createPlanets()
	{
		for (int i = 0; i < Random.Range(minPlanetsInSystem, maxPlanetsInSystem); i++)
		{
			GameObject planet;

			if (firstPlanetCreated == false)
			{
				firstPlanetCreated = true;
				lastSpawnDistance = minDistanceFromSun;
				planet = Instantiate (availablePlanets[Random.Range(0, availablePlanets.Length)], objectPosition(lastSpawnDistance, maxPlanetSpacing, sunPos), Quaternion.identity) as GameObject;
				solarSystemObjects.Add(planet);
			}
			else
			{
				planet = Instantiate (availablePlanets[Random.Range(0, availablePlanets.Length)], objectPosition(lastSpawnDistance, maxPlanetSpacing, sunPos), Quaternion.identity) as GameObject;
				solarSystemObjects.Add(planet);
			}
		}
	}

	//this works because reasons 
	Vector3 objectPosition(float min, float max, Vector3 sunPos)
	{
		Vector3 pos = new Vector3(Random.Range(-(min + max),min + max),0,Random.Range(-(min + max),min + max));
		for (int i = 0; i < 1000; i++)
		{
			pos = new Vector3(Random.Range(-(min + max),min + max),0,Random.Range(-(min + max),min + max));
			if (Vector3.Distance(sunPos, pos) >= lastSpawnDistance)
			{
				lastSpawnDistance = Vector3.Distance(sunPos, pos) + minPlanetSpacing;
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

	public void pauseGame(bool isPaused)
	{
		if (isPaused)
		{
			Time.timeScale = 0;
			globalPause = true;
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerProjectile"))
			{
				Destroy(obj);
			}
		}

		if (!isPaused)
		{
			Time.timeScale = 1;
			globalPause = false;
		}
	}
}
