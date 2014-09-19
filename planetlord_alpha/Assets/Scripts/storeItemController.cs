using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class storeItemController : MonoBehaviour 
{
	public Sprite itemIcon;
	public string itemName;
	public string itemDesc;
	public float itemCost;
	public string itemType;
	public GameObject item;
	public GameObject itemSource;

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
			if (itemType == "Weapon")
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().weaponsInv[1] = item;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().resourcesCollected -= itemCost;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().refreshEquipment();
				Destroy(this.gameObject);
				itemSource.GetComponent<planetProperties>().planetInventory.Remove(item);
			}
			if (itemType == "Armor")
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().armorEquipped = item;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().resourcesCollected -= itemCost;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().refreshEquipment();
				Destroy(this.gameObject);
				itemSource.GetComponent<planetProperties>().planetInventory.Remove(item);
			}
			if (itemType == "Engine")
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().engineEquipped = item;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().resourcesCollected -= itemCost;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().refreshEquipment();
				Destroy(this.gameObject);
				itemSource.GetComponent<planetProperties>().planetInventory.Remove(item);
			}
			if (itemType == "Thruster")
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().thrusterEquipped = item;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().resourcesCollected -= itemCost;
				GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().refreshEquipment();
				Destroy(this.gameObject);
				itemSource.GetComponent<planetProperties>().planetInventory.Remove(item);
			}
		}
	}
}
