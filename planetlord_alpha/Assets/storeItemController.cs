using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class storeItemController : MonoBehaviour 
{
	public Sprite itemIcon;
	public string itemName;
	public string itemDesc;
	public float itemCost;

	public GameObject itemIconContainer;
	public GameObject itemNameContainer;
	public GameObject itemDescContainer;
	public GameObject itemCostContainer;

	void Update()
	{
		itemIconContainer.GetComponent<Image>().sprite = itemIcon;
		itemNameContainer.GetComponent<Text>().text = itemName;
		itemDescContainer.GetComponent<Text>().text = itemDesc;
		itemCostContainer.GetComponent<Text>().text = itemCost + " Resources";
	}
}
