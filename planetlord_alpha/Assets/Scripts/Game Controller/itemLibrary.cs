using UnityEngine;
using System.Collections;

public class itemLibrary : MonoBehaviour 
{
	public GameObject[][] itemsLibrary;
	public GameObject[] weaponsLibrary;
	public GameObject[] engineLibrary;
	public GameObject[] thrusterLibrary;
	public GameObject[] armorLibrary;

	void Awake()
	{
		itemsLibrary = new GameObject[4][];

		itemsLibrary[0] = weaponsLibrary;
		itemsLibrary[1] = engineLibrary;
		itemsLibrary[2] = thrusterLibrary;
		itemsLibrary[3] = armorLibrary;

	}
}
