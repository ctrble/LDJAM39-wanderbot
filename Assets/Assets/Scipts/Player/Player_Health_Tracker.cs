using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health_Tracker : MonoBehaviour {

	public Game_Controller gameController;
	private Player_States playerState;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		if (playerState == null)
			playerState = gameObject.GetComponentInParent<Player_States> ();

		//subscribe to this delegate
		Laser_Controller.onHit += TakeDamage;
	}

	void OnDisable () {

		//unsubscribe to this delegate
		Laser_Controller.onHit -= TakeDamage;
	}

	void TakeDamage (GameObject hitObject) {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && hitObject.transform.parent == gameObject.transform.GetChild (0))
			ChangeHealth (-1);
	}

	void ChangeHealth (int healthChange) {

		Game_Controller.playerHealth += healthChange;
		Debug.Log (Game_Controller.playerHealth);
//		if (Game_Controller.playerHealth == 0)
//			Die ();
	}

//	void Die () {
//	
//		if (gameController.currentState == Game_Controller.Game_State.Playing_State) {
//		
//
//		}
//	}

//	void ChangeToDead () {
//
//		if (!Input.GetButton ("Horizontal") && !Input.GetButton ("Vertical"))
//			ExitState ("idle");
//	}
}
