using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour 
{
	// ui control variables
	public bool toggleMap;
	public bool currentlyTrackingTarget;

	//engine variables
	public float dragMultiplier;
	public float initialDrag;

	private float initialAccel;
	private float acceleration;

	//thruster variables
	public float boostFuel;
	private float boostStrength;
	private float boostRefuelRate;
	private float fuelUseRate;
	private float boostCoolingPoint;
	private float maxBoostFuel;
	private bool boostOverheat;

	public float subLightStrength;
	public bool subLightDrive;

	//inventory variables
	public GameObject[] weaponsInv;
	public GameObject engineEquipped;
	public GameObject thrusterEquipped;
	public GameObject armorEquipped;
	public GameObject shieldEquipped;

	private GameObject currentlySelectedWeapon;
	private float weaponFireDelay;

	//status variables
	public float armorValue;
	public float resourcesCollected;
	public float shieldValue;

	private float maxShieldValue;
	private float maxArmorValue;
	private GameObject currentlyEquippedShield;
	public string[] damagedBy;
	public string pickUps;
	public string gravWell;

	//tracking variables
	public string gameController;
	public GameObject currentTrackedTarget;

	public int currentTargetSelection;
	public List<GameObject> trackableTargets;

	public string deathScene;

	void Awake()
	{
		//initialize values
		armorValue = armorEquipped.GetComponent<equipmentProperties>().armorValue;
		maxArmorValue = armorEquipped.GetComponent<equipmentProperties>().armorValue;

		shieldValue = shieldEquipped.GetComponent<equipmentProperties>().shieldValue;
		maxShieldValue = armorEquipped.GetComponent<equipmentProperties>().shieldValue;

		refreshEquipment();

		rigidbody.drag = initialDrag;

		boostOverheat = false;

		subLightDrive = true;

		currentTargetSelection = -1;
		currentlyTrackingTarget = false;

		toggleMap = false;
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
			if (subLightDrive)
			{
				subLightControl(true);
			}
			else
			{
				boostControl(true);
			}
		}

		if (Input.GetButtonUp("Boost"))
		{
			subLightControl(false);
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

		if (!subLightDrive)
		{
			if(Input.GetButton("FireWeapon"))
			{
				fireWeapon();
			}
		}

		if (Input.GetButtonDown("SwitchTarget"))
		{
			switchTarget();
		}

		if (Input.GetButtonDown("ToggleMap"))
		{
			toggleMap = !toggleMap;
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

	void subLightControl(bool isActive)
	{
		if (isActive)
		{
			acceleration = initialAccel * subLightStrength;
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
		if (weaponsInv[selection] != null)
		{
			currentlySelectedWeapon = weaponsInv[selection];
		}
	}

	void fireWeapon()
	{
		if (weaponFireDelay <= 0)
		{
			Instantiate(currentlySelectedWeapon, transform.position, transform.rotation);
			weaponFireDelay = currentlySelectedWeapon.GetComponent<equipmentProperties>().weaponFireDelay;
		}
	}
	//target tracking control
	void targetTrackingController()
	{
		trackableTargets = GameObject.FindGameObjectWithTag(gameController).GetComponent<gameController>().trackableTargets;

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
		
		if (currentTargetSelection > trackableTargets.Count - 1)
		{
			currentTargetSelection = -1;
		}
	}

	void switchTarget()
	{
		if (currentTargetSelection < trackableTargets.Count -1)
		{
			currentTargetSelection += 1;
		}
		else
		{
			currentTargetSelection = -1;
		}
	}

	//status control

	void statusListener()
	{
		weaponFireDelay -= Time.deltaTime;

		if (armorValue <= 0)
		{
			deathEvent();
		}

		if (shieldValue <= 0)
		{
			currentlyEquippedShield.SetActive(false);
		}
		else
		{
			currentlyEquippedShield.SetActive(true);
		}
	}

	public void refreshEquipment()
	{
		//engine
		acceleration = engineEquipped.GetComponent<equipmentProperties>().acceleration;
		initialAccel = acceleration;

		//thruster
		boostStrength = thrusterEquipped.GetComponent<equipmentProperties>().boostStrength;
		boostFuel = thrusterEquipped.GetComponent<equipmentProperties>().boostFuel;
		boostRefuelRate = thrusterEquipped.GetComponent<equipmentProperties>().boostRefuelRate;
		fuelUseRate = thrusterEquipped.GetComponent<equipmentProperties>().fuelUseRate;
		boostCoolingPoint = thrusterEquipped.GetComponent<equipmentProperties>().boostCoolingPoint;
		maxBoostFuel = boostFuel;

		//armor
		if (armorValue == maxArmorValue)
		{
			armorValue = armorEquipped.GetComponent<equipmentProperties>().armorValue;
			maxArmorValue = armorEquipped.GetComponent<equipmentProperties>().armorValue;
		}
		else
		{
			maxArmorValue = armorEquipped.GetComponent<equipmentProperties>().armorValue;
		}

		//shield
		if (shieldValue == maxShieldValue)
		{
			shieldValue = shieldEquipped.GetComponent<equipmentProperties>().shieldValue;
			maxShieldValue = armorEquipped.GetComponent<equipmentProperties>().shieldValue;
			currentlyEquippedShield = Instantiate(shieldEquipped, transform.position, Quaternion.identity) as GameObject;
			currentlyEquippedShield.transform.parent = transform;
		}
		else
		{
			maxShieldValue = armorEquipped.GetComponent<equipmentProperties>().shieldValue;
			currentlyEquippedShield = Instantiate(shieldEquipped, transform.position, Quaternion.identity) as GameObject;
			currentlyEquippedShield.transform.parent = transform;
		}

		currentlySelectedWeapon = weaponsInv[0];


	}

	void dealDamage(float damageValue)
	{
		if (shieldValue <=0)
		{
			armorValue -= damageValue;
		}
		else
		{
			shieldValue -= damageValue;
		}
	}

	void deathEvent()
	{
		Application.LoadLevel(deathScene);
	}

	//collision control
	void OnTriggerEnter(Collider other)
	{
		foreach(string tag in damagedBy)
		{
			if(other.gameObject.tag == tag)
			{
				dealDamage(other.gameObject.GetComponent<equipmentProperties>().baseDamage);
				Destroy(other.gameObject);
			}
		}

		if (other.gameObject.tag == pickUps)
		{
			resourcesCollected += other.gameObject.GetComponent<pickupProperties>().resourceAmount;
			Destroy(other.gameObject);
		}

		if (other.gameObject.tag == gravWell)
		{
			subLightDrive = false;
			subLightControl(false);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == gravWell)
		{
			subLightDrive = true;
		}
	}
}
