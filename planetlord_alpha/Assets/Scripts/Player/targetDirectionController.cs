using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class targetDirectionController : MonoBehaviour 
{
	private Vector3 enemyPos;
	
	public string playerShip;

	private bool currentlyTrackingTarget;
	private GameObject currentTrackedTarget;
	private float targetDir;

	void Awake()
	{
		targetDir = 0;
	}
	void Update () 
	{
		currentTrackedTarget = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().currentTrackedTarget;
		currentlyTrackingTarget = GameObject.FindGameObjectWithTag(playerShip).GetComponent<playerController>().currentlyTrackingTarget;

		transform.eulerAngles = new Vector3(0, 0, targetDir);
		
		GetComponent<Image>().enabled = currentlyTrackingTarget;

		if (currentlyTrackingTarget)
		{
			targetDir = rotDirection();
		}
	}
	float rotDirection()
	{
			if (currentTrackedTarget.transform.position.z < GameObject.FindGameObjectWithTag(playerShip).transform.position.z )
			{
				return 180 + (-1*(Mathf.Rad2Deg*(Mathf.Atan ((currentTrackedTarget.transform.position.x - GameObject.FindGameObjectWithTag(playerShip).transform.position.x)/(currentTrackedTarget.transform.position.z - GameObject.FindGameObjectWithTag(playerShip).transform.position.z)))) );
			}
			else
			{
				return (-1*(Mathf.Rad2Deg*(Mathf.Atan ((currentTrackedTarget.transform.position.x - GameObject.FindGameObjectWithTag(playerShip).transform.position.x)/(currentTrackedTarget.transform.position.z - GameObject.FindGameObjectWithTag(playerShip).transform.position.z)))) );
			}
	}
}
