using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Tracker : MonoBehaviour {

	public Game_Controller gameController;
	public Player_States playerState;
	public Player_Movement playerMovement;
	public AmbientLight ambientLight;

	public float chargeTimer = 0.0f;
	public float movementTimer = 0.0f;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent<Game_Controller> ();

		if (playerState == null)
			playerState = gameObject.GetComponentInParent<Player_States> ();

		if (playerMovement == null)
			playerMovement = gameObject.GetComponentInChildren<Player_Movement> ();
	}

	void Update () {
	
		if (gameController.currentState == Game_Controller.Game_State.Playing_State) {
		
			if (playerState.currentState == Player_States.Player_State.Move_State) {

				movementTimer += Time.deltaTime;

				MovementEnergy (movementTimer);

			} else if (playerState.currentState != Player_States.Player_State.Move_State) {

				movementTimer = 0;
			}

			if (ambientLight.transition <= 0.6f) {
			
				chargeTimer += Time.deltaTime;
				ChargeInSun (chargeTimer);
			} else {
			
				chargeTimer = 0;
			}
		}
	}

	void ChargeInSun (float timeSunning) {
	
		if (timeSunning >= 1) {
			
			ChangeEnergy (1);
			chargeTimer = 0;
		}
	}

	void MovementEnergy (float timeMoved) {

		if (playerMovement == null)
			playerMovement = gameObject.GetComponentInChildren<Player_Movement> ();

		float seconds = 1;

		if (playerMovement.turboMode)
			seconds = 0.5f;
		else
			seconds = 1;

		if (timeMoved >= seconds) {

			ChangeEnergy (-1);
			movementTimer = 0;
		}
	}

	public void ShootingEnergy (int shot) {
		
		ChangeEnergy (-shot);
	}

	void ChangeEnergy (int energyChange) {

		Game_Controller.playerEnergy += energyChange;
	}
}
