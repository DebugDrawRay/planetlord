using UnityEngine;
using System.Collections;

public class planetInteractionMenuController : MonoBehaviour 
{
	public GameObject[] planetInventory;

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
			itemListing.GetComponent<storeItemController>().itemIcon = item.GetComponent<projectileProperties>().icon;
			itemListing.GetComponent<storeItemController>().itemDesc = item.GetComponent<projectileProperties>().description;
			itemListing.GetComponent<storeItemController>().itemCost = item.GetComponent<projectileProperties>().cost;
			itemListing.GetComponent<storeItemController>().itemName = item.GetComponent<projectileProperties>().name;
			itemListing.GetComponent<storeItemController>().item = item;
		}
	}
	public void endInteraction()
	{
		GameObject.FindGameObjectWithTag(inGameUi).GetComponent<uiController>().planetButtonActive = true;
		GameObject.FindGameObjectWithTag(gameController).GetComponent<gameController>().pauseGame(false);

		Destroy(this.gameObject);
	}
	
}
