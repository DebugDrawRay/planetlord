using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour 
{
	private float despawnTimer;
	void Start () 
	{
		rigidbody.velocity = (transform.forward * GetComponent<projectileProperties>().baseSpeed);
		despawnTimer = GetComponent<projectileProperties>().despawnTimer;
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
