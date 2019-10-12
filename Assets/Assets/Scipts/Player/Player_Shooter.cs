using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooter : MonoBehaviour {

	public Game_Controller gameController;
	public Player_States playerState;
	public Energy_Tracker energyTracker;

	public GameObject laser;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		if (playerState == null)
			playerState = gameObject.GetComponentInParent<Player_States> ();

		if (energyTracker == null)
			energyTracker = gameObject.GetComponentInParent<Energy_Tracker> ();
	}

	void Update () {
	
		if (gameController.currentState == Game_Controller.Game_State.Playing_State && playerState.currentState != Player_States.Player_State.Empty_State) {

			if (Input.GetButtonDown ("Primary") && Game_Controller.playerEnergy > 0) {
				Instantiate (laser, transform.position, transform.rotation);
				energyTracker.ShootingEnergy (1);
			}
		}
	}
}
