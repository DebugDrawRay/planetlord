using UnityEngine;
using System.Collections;

public class floatingObject : MonoBehaviour 
{
	public float force;
	void Start()
	{
 		rigidbody.AddForce(new Vector3(Random.Range(-force, force), 0, Random.Range(-force, force)));
	}
}
