using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class defaultPlanetController : MonoBehaviour
{
	private List<GameObject> childEnemies;
	private bool isCaptured;

	void Awake()
	{
		isCaptured = false;
		childEnemies = GetComponent<planetProperties>().childEnemies;
		transform.position += new Vector3 (0, GetComponent<planetProperties>().floatOffset, 0);
	}

	void Update()
	{
		planetStatusController();

		childEnemies = GetComponent<planetProperties>().childEnemies;
		GetComponent<planetProperties>().isCaptured  = isCaptured; 
	}

	void planetStatusController()
	{
		checkPlanetCapture();
		checkActiveEnemies();
	}

	void checkActiveEnemies()
	{
		for(int i = 0; i <= childEnemies.Count - 1; i++)
		{
			if(childEnemies[i].GetComponent<enemyProperties>().isDead || childEnemies[i] == null)
			{
				GetComponent<planetProperties>().childEnemies.RemoveAt(i);
			}
		}
	}
	void checkPlanetCapture()
	{
		if (childEnemies.Count <= 0)
		{
			GetComponentInChildren<MeshRenderer>().renderer.material.color = Color.green;
			isCaptured = true;
		}
	}
}
