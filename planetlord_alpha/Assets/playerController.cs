using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour 
{
	//engine variables
	public float dragMultiplier;
	public float initialDrag;

	private float initialAccel;
	public float acceleration;

	public float boostFuel;
	public float boostStrength;
	public float boostRefuelRate;
	public float fuelUseRate;
	public float boostCoolingPoint;
	private float maxBoostFuel;
	private bool boostOverheat;

	//weapon variables
	public GameObject[] weaponsInv;
	private GameObject currentlySelectedWeapon;
	private float weaponFireDelay;

	//status variables
	public float armorValue;
	private float maxArmorValue;
	public string[] damagedBy;

	//tracking variables
	public GameObject gameController;
	public GameObject currentTrackedTarget;

	public bool currentlyTrackingTarget;

	public int currentTargetSelection;
	public List<GameObject> trackableTargets;

	void Awake()
	{
		//initialize values
		rigidbody.drag = initialDrag;
		initialAccel = acceleration;
		maxBoostFuel = boostFuel;
		boostOverheat = false;
		currentlySelectedWeapon = weaponsInv[0];
		currentTargetSelection = -1;
		currentlyTrackingTarget = false;
	}

	void Update()
	{
		inputListener();
		statusListener();
		targetTrackingController();
		boostRefuel();
	}

	//Handles all input from the player.
	void inputListener()
	{
	
		float horizontalAxis = Input.GetAxisRaw("Horizontal");
		float verticalAxis = Input.GetAxisRaw("Vertical");

		engineControl(horizontalAxis, verticalAxis);
		lookAtMouse();

		if (Input.GetButton("Boost"))
		{
			boostControl(true);
		}

		if (Input.GetButtonUp("Boost"))
		{
			boostControl(false);
		}

		if (Input.GetButtonDown("Brake"))
		{
			stopMovement();
		}

		if (Input.GetButton("Weapon1"))
		{
			weaponSelect(0);
		}
		else if (Input.GetButton("Weapon2"))
		{
			weaponSelect(1);
		}

		if(Input.GetButton("FireWeapon"))
		{
			fireWeapon();
		}

		if (Input.GetButtonDown("SwitchTarget"))
		{
			switchTarget();
		}
	}

	//Movement Controls
	void engineControl(float h, float v)
	{
		rigidbody.drag = initialDrag * (rigidbody.velocity.magnitude * dragMultiplier);
		rigidbody.AddForce (Vector3.forward * v * acceleration);
		rigidbody.AddForce (Vector3.right * h * acceleration);
	}

	void boostControl(bool isActive)
	{
		if (boostFuel > 0 && !boostOverheat && isActive)
		{
			boostFuel -= fuelUseRate;
			acceleration = initialAccel * boostStrength;
		}
		else if(boostFuel <= 0)
		{
			acceleration = initialAccel;
		}
		else if(!isActive)
		{
			acceleration = initialAccel;
		}
	}

	void boostRefuel()
	{
		if (boostFuel < maxBoostFuel)
		{
			boostFuel += boostRefuelRate;
		}
		if (boostFuel <= 0)
		{
			boostOverheat = true;
		}
		if (boostFuel >= maxBoostFuel/boostCoolingPoint)
		{
			boostOverheat = false;
		}
	}

	void stopMovement()
	{
		rigidbody.velocity = Vector3.zero;
	}

	void lookAtMouse()
	{
		transform.LookAt(new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z));
	}

	//weapons control

	void weaponSelect(int selection)
	{
		if (selection <= weaponsInv.Length)
		{
			currentlySelectedWeapon = weaponsInv[selection];
		}
	}

	void fireWeapon()
	{
		if (weaponFireDelay <= 0)
		{
			Instantiate(currentlySelectedWeapon, transform.position, transform.rotation);
			weaponFireDelay = currentlySelectedWeapon.GetComponent<projectileProperties>().weaponFireDelay;
		}
	}
	//target tracking control
	void targetTrackingController()
	{
		trackableTargets = gameController.GetComponent<gameController>().trackableTargets;

		if (trackableTargets.Count > 0)
		{
			if (currentTargetSelection == -1)
			{
				currentlyTrackingTarget = false;
			}
			else
			{
				currentTrackedTarget = trackableTargets[currentTargetSelection];
				currentlyTrackingTarget = true;
			}
		}
		else
		{
			currentlyTrackingTarget = false;
			currentTargetSelection = -1;
		}
		
		if (trackableTargets.Count - 1 < currentTargetSelection)
		{
			currentTargetSelection = -1;
		}
	}

	void switchTarget()
	{
		currentTargetSelection += 1;
	}

	//status control

	void statusListener()
	{
		weaponFireDelay -= Time.deltaTime;

		if (armorValue <= 0)
		{
			deathEvent();
		}
	}

	void dealDamage(float damageValue)
	{
		armorValue -= damageValue;
	}

	void deathEvent()
	{
		Application.Quit();
	}

	//collision control
	void OnTriggerEnter(Collider other)
	{
		foreach(string tag in damagedBy)
		{
			if(other.gameObject.tag == tag)
			{
				dealDamage(other.gameObject.GetComponent<projectileProperties>().baseDamage);
				Destroy(other.gameObject);
			}
		}
	}

}
