using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerActionsController : MonoBehaviour 
{

	void Update()
	{
		inputListener();
	}

	//Handles all input from the player.
	void inputListener();
	{
		float horizontalAxis = Input.GetAxisRaw("Horizontal");
		float verticalAxis = Input.GetAxisRaw("Vertical");

		engineControl(horizontalAxis, verticalAxis);
		if (Input.GetButtonDown("Jump"))
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
			fireProjectile();
		}
	}
}
