using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class collisionReactionController : MonoBehaviour 
{
	public GameObject onHitAnim;
	public float knockbackStrength;
	public float hitObjDespawnTimer;
	public string[] damagedBy;

	void OnTriggerEnter(Collider other)
	{
		foreach(string tag in damagedBy)
		{
			if(other.gameObject.tag == tag)
			{
				GameObject hitAnim;
				hitAnim = Instantiate(onHitAnim, transform.position + new Vector3(0,3,0), Quaternion.identity) as GameObject;
				hitAnim.GetComponent<onHitObjController>().despawnTimer = hitObjDespawnTimer;
				rigidbody.AddForce((new Vector3(Random.Range(-1,2), 0, Random.Range(-1,2)) * knockbackStrength));
			}
		}
	}
}
