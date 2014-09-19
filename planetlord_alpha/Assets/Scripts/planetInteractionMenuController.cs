using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class planetInteractionMenuController : MonoBehaviour 
{
	public List<GameObject> planetInventory;

	public GameObject planetToInteract;

	public GameObject itemListingContainer;

	public float listingSpacing;
	private float itemPosition;

	public string inGameUi;
	public string gameController;

	void Start()
	{
		itemPosition = listingSpacing * 2;
		createStoreItem();
	}

	void createStoreItem()
	{
		foreach (GameObject item in planetInventory)
		{
			GameObject itemListing;
			itemPosition -= listingSpacing;

			itemListing = Instantiate(itemListingContainer) as GameObject;
			itemListing.transform.SetParent(transform, false);
			itemListing.transform.localPosition += new Vector3(0, itemPosition, 0);
			itemListing.GetComponent<storeItemController>().itemIcon = item.GetComponent<equipmentProperties>().icon;
			itemListing.GetComponent<storeItemController>().itemDesc = item.GetComponent<equipmentProperties>().description;
			itemListing.GetComponent<storeItemController>().itemCost = item.GetComponent<equipmentProperties>().cost;
			itemListing.GetComponent<storeItemController>().itemName = item.GetComponent<equipmentProperties>().name;
			itemListing.GetComponent<storeItemController>().itemType = item.GetComponent<equipmentProperties>().type;
			itemListing.GetComponent<storeItemController>().item = item;
			itemListing.GetComponent<storeItemController>().itemSource = planetToInteract;
		}
	}
	public void endInteraction()
	{
		GameObject.FindGameObjectWithTag(inGameUi).GetComponent<uiController>().planetButtonActive = true;
		GameObject.FindGameObjectWithTag(gameController).GetComponent<gameController>().pauseGame(false);

		Destroy(this.gameObject);
	}
	
}
