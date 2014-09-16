using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class storeItemController : MonoBehaviour 
{
	public Sprite itemIcon;
	public string itemName;
	public string itemDesc;
	public float itemCost;
	public GameObject item;

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

	public void buyItem()
	{
		if (itemCost <= GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().resourcesCollected)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().weaponsInv[1] = item;
			GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().resourcesCollected -= itemCost;
			Destroy(this.gameObject);
		}
	}
}
