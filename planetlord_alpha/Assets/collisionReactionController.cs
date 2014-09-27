using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class collisionReactionController : MonoBehaviour 
{
	public GameObject[] reactiveObjects;
	public GameObject onHitAnim;
	public Color reactionColor;
	private Color initialColor;
	public float reactionTime;
	private float initialReactionTime;
	public float knockbackStrength;
	public float hitObjDespawnTimer;
	public string[] damagedBy;

	void Awake()
	{
		foreach(GameObject obj in reactiveObjects)
		{
			initialColor = obj.renderer.material.color;
		}
		initialReactionTime = reactionTime;
	}

	void Update()
	{
		reactionTime -= Time.deltaTime;
		if (reactionTime <= 0)
		{
			foreach(GameObject obj in reactiveObjects)
			{
				obj.renderer.material.color = initialColor;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		foreach(string tag in damagedBy)
		{
			if(other.gameObject.tag == tag)
			{
				foreach(GameObject obj in reactiveObjects)
				{
					obj.renderer.material.color = reactionColor;
				}

				GameObject hitAnim;
				hitAnim = Instantiate(onHitAnim, transform.position, Quaternion.identity) as GameObject;
				hitAnim.GetComponent<onHitObjController>().despawnTimer = hitObjDespawnTimer;

				rigidbody.AddForce((new Vector3(Random.Range(-1,2), 0, Random.Range(-1,2)) * knockbackStrength));
				reactionTime = initialReactionTime;
			}
		}
	}
}
