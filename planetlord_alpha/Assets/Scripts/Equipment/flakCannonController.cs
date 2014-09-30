using UnityEngine;
using System.Collections;

public class flakCannonController : MonoBehaviour 
{
	private float despawnTimer;
	private GameObject equipmentOwner;
	public GameObject flakObject;
	void Start () 
	{
		despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
		equipmentOwner = GetComponent<equipmentProperties>().equipmentOwner;
		for(var i = 1; i <= GetComponent<equipmentProperties>().projectilesInShot; i ++)
		{
			GameObject projectile;
			float fireRot;
			fireRot = ((GetComponent<equipmentProperties>().fireCone / GetComponent<equipmentProperties>().projectilesInShot) * i) - ((GetComponent<equipmentProperties>().fireCone / GetComponent<equipmentProperties>().projectilesInShot)) - (GetComponent<equipmentProperties>().fireCone / 2);
			projectile = Instantiate(flakObject, transform.position, transform.rotation) as GameObject;
			projectile.transform.eulerAngles += new Vector3 (0, fireRot, 0);
			projectile.rigidbody.velocity = (projectile.transform.forward * GetComponent<equipmentProperties>().baseSpeed + equipmentOwner.rigidbody.velocity);
			projectile.GetComponent<flakObjectController>().despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
			projectile.GetComponent<equipmentProperties>().baseDamage = GetComponent<equipmentProperties>().baseDamage;
		}
	}
	
	void Update () 
	{
		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
