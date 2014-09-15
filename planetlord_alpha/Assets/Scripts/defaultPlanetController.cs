using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class defaultPlanetController : MonoBehaviour
{
	private List<GameObject> childEnemies;
	private bool isCaptured;
	private string playerShip;
	private string inGameUI;

	void Awake()
	{
		isCaptured = false;
		childEnemies = GetComponent<planetProperties>().childEnemies;
		transform.position += new Vector3 (0, GetComponent<planetProperties>().floatOffset, 0);
		playerShip = GetComponent<planetProperties>().playerShip;
		inGameUI = GetComponent<planetProperties>().inGameUI;
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
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == playerShip && isCaptured)
		{
			GameObject.FindGameObjectWithTag(inGameUI).GetComponent<uiController>().planetButtonActive = true;
			GameObject.FindGameObjectWithTag(inGameUI).GetComponent<uiController>().planetToInteract = this.gameObject;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == playerShip && isCaptured)
		{
			GameObject.FindGameObjectWithTag(inGameUI).GetComponent<uiController>().planetButtonActive = false;
		}
	}
}
