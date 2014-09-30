using UnityEngine;
using System.Collections;

public class equipmentProperties : MonoBehaviour 
{
	public float baseDamage;
	public float baseSpeed;
	private float initialBaseSpeed;

	public float shieldValue;
	public string[] shieldBlocks;

	public float despawnTimer;
	public float weaponFireDelay;

	public float projectilesInShot;
	public float fireCone;

	public float maxBeamLength;
	public float beamLengthIncrease;

	public float acceleration;
	
	public float boostFuel;
	public float boostStrength;
	public float boostRefuelRate;
	public float fuelUseRate;
	public float boostCoolingPoint;

	public float armorValue;

	public GameObject equipmentOwner;
	public string type;
	public string name;
	public string description;
	public float cost;
	public Sprite icon;
}
