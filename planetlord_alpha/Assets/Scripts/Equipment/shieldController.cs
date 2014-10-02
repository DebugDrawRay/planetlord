using UnityEngine;
using System.Collections;

public class shieldController : MonoBehaviour 
{
	public bool shieldHit;
	private string[] shieldBlocks;
	public GameObject[] reactiveObjects;
	public Color reactionColor;
	private Color initialColor;
	public float reactionTime;
	private float initialReactionTime;

	void Awake()
	{
		shieldBlocks = GetComponent<equipmentProperties>().shieldBlocks;
		initialReactionTime = reactionTime;

		foreach(GameObject obj in reactiveObjects)
		{
			initialColor = obj.GetComponent<SpriteRenderer>().color;
		}
	}

	void Update()
	{
		reactionTime -= Time.deltaTime;
		if (reactionTime <= 0)
		{
			foreach(GameObject obj in reactiveObjects)
			{
				obj.GetComponent<SpriteRenderer>().color = initialColor;
			}
		}

		shieldHit = false;
	}
	void OnTriggerEnter(Collider other)
	{
		foreach(string hit in shieldBlocks)
		{
			if(other.gameObject.tag == hit)
			{
				foreach(GameObject obj in reactiveObjects)
				{
					obj.GetComponent<SpriteRenderer>().color = reactionColor;
				}
				reactionTime = initialReactionTime;
				shieldHit = true;
				Destroy(other.gameObject);
			}
		}
	}
}
