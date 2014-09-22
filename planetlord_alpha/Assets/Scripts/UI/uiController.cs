using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class uiController : MonoBehaviour 
{
	public float miniMapRelDistance;

	public string sunTag;

	public bool planetButtonActive;
	public bool planetMenuActive;
	public bool isInteractingWithPlanet;
	public GameObject planetToInteract;

	public GameObject planetImage;
	public GameObject sunImage;
	public GameObject miniMapContainer;
	public GameObject gameController;
	public GameObject planetInteractionButton;
	public GameObject planetInteractionMenu;
	public List<GameObject> solarSystemObjects;

	void Start()
	{
		solarSystemObjects = gameController.GetComponent<gameController>().solarSystemObjects;
		miniMapGeneration();
		isInteractingWithPlanet = false;
	}

	void Update()
	{
		planetInteractionController();
	}

	void miniMapGeneration()
	{
		for (int i = 0; i <= solarSystemObjects.Count - 1; i++)
		{
			generateMiniMapObjects(solarSystemObjects[i]);
		}
	}

	void generateMiniMapObjects(GameObject mapObject)
	{
		if (mapObject.tag == sunTag)
		{
			GameObject miniMapObject;
			miniMapObject = Instantiate(sunImage, Vector3.zero, Quaternion.identity) as GameObject; 
			miniMapObject.transform.parent = miniMapContainer.transform;
			miniMapObject.transform.localPosition = new Vector3 (mapObject.transform.position.x/miniMapRelDistance, mapObject.transform.position.z/miniMapRelDistance, 0);
			miniMapObject.transform.localRotation = new Quaternion(0,0,0,1);
		}
		else
		{
			GameObject miniMapObject;
			miniMapObject = Instantiate(planetImage, Vector3.zero, Quaternion.identity) as GameObject; 
			miniMapObject.transform.parent = miniMapContainer.transform;
			miniMapObject.transform.localPosition = new Vector3 (mapObject.transform.position.x/miniMapRelDistance, mapObject.transform.position.z/miniMapRelDistance, 0);
			miniMapObject.transform.localRotation = new Quaternion(0,0,0,1);
		}
	}

	void planetInteractionController()
	{
		planetInteractionButton.SetActive(planetButtonActive);
	}

	public void createPlanetMenu()
	{
		gameController.GetComponent<gameController>().pauseGame(true);
		gameController.GetComponent<gameController>().toggleCursor(false);
		planetButtonActive = false;

		GameObject menu;
		menu = Instantiate(planetInteractionMenu) as GameObject;
		menu.GetComponent<planetInteractionMenuController>().planetInventory = planetToInteract.GetComponent<planetProperties>().planetInventory;
		menu.GetComponent<planetInteractionMenuController>().planetToInteract = planetToInteract;
	}	
}
