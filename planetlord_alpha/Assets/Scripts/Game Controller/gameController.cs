using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameController : MonoBehaviour 
{
	//player systems generation
	public GameObject playerShip;
	public Vector3 playerSpawnPos;
	public GameObject mainUI;
	public GameObject warpGate;

	//solar system variables

	public GameObject[] availableSuns;
	public GameObject[] availablePlanets;
	public GameObject spaceBackground;

	public List<GameObject> solarSystemObjects;
	public List<GameObject> trackableTargets;
	public bool systemConquered;
	public GameObject warpGateContainer;

	public int maxPlanetsInSystem;
	public int minPlanetsInSystem;

	public float minPlanetSpacing;
	public float maxPlanetSpacing;
	public float minDistanceFromSun;

	public float lastSpawnDistance;
	
	public bool globalPause;
	public bool targetingCur;

	private Vector3 sunPos;

	private bool firstPlanetCreated;

	void Awake()
	{
		toggleCursor(true);
		systemConquered = false;

		sunPos = Vector3.zero;

		solarSystemGenerationController();
		spawnPlayer();
	}

	void Update()
	{
		checkIfConquered(); 
	}

	//set up cursor and player
	void spawnPlayer()
	{
		Instantiate (mainUI);

		GameObject player;
		player = Instantiate (playerShip, playerSpawnPos, Quaternion.identity) as GameObject;

		warpGateContainer = Instantiate (warpGate, player.transform.position, Quaternion.identity) as GameObject;

	}

	public void toggleCursor(bool active)
	{
		if (active)
		{
			Screen.showCursor = false;
			targetingCur = true;
		}
		else if (!active)
		{
			Screen.showCursor = true;
			targetingCur = false;
		}
	}

	//generate the solar system

	void solarSystemGenerationController()
	{
		createSun();
		Instantiate(spaceBackground, new Vector3(0, -1000, 0), Quaternion.identity);
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

	void checkIfConquered()
	{
		if (solarSystemObjects.Count > 0)
		{
			for (int i = 0; i <= solarSystemObjects.Count - 1; i++)
			{
				if (solarSystemObjects[i].GetComponent<planetProperties>().isCaptured)
				{
					solarSystemObjects.RemoveAt(i);
				}
			}
		}
		else
		{
			systemConquered = true;
		}
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
