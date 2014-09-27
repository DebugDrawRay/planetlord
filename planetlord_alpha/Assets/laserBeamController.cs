using UnityEngine;
using System.Collections;

public class laserBeamController : MonoBehaviour 
{
	private float maxBeamLength;
	private float despawnTimer;
	private string equipmentOwner;

	void Awake () 
	{
		maxBeamLength = GetComponent<equipmentProperties>().maxBeamLength;
		despawnTimer = GetComponent<equipmentProperties>().despawnTimer;
		equipmentOwner = GetComponent<equipmentProperties>().equipmentOwner;


	}
	void Update () 
	{
		GetComponent<BoxCollider>().center = new Vector3(0,0, ((Vector3.Distance(GameObject.FindGameObjectWithTag(equipmentOwner).transform.position, new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z)))/2));
		GetComponent<BoxCollider>().size = new Vector3(1,1, Vector3.Distance(GameObject.FindGameObjectWithTag(equipmentOwner).transform.position, new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z)));
		transform.LookAt(new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z));
		GetComponent<LineRenderer>().SetPosition(0, GameObject.FindGameObjectWithTag(equipmentOwner).transform.position);
		GetComponent<LineRenderer>().SetPosition(1, new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z));
		despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0)
		{
			Destroy (gameObject);
		}
	}
}
