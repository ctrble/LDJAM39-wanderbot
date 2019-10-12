using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_State : MonoBehaviour {

	private Game_Controller gameController;
	private Player_States playerStates;

	private bool idle;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();
		
		if (playerStates == null) {
			playerStates = gameObject.GetComponent<Player_States> ();
		}
	}

	public void EnterState () {

//		Debug.Log ("idle state");
		idle = true;
	}

	public void ExitState (string nextState) {

		if (nextState == "move") {
		
			idle = false;
			playerStates.currentState = Player_States.Player_State.Move_State;
			playerStates.ChangeState ();
		}

		if (nextState == "empty") {

			idle = false;
			playerStates.currentState = Player_States.Player_State.Empty_State;
			playerStates.ChangeState ();
		}

		if (nextState == "dead") {

			playerStates.currentState = Player_States.Player_State.Dead_State;
			playerStates.ChangeState ();
		}
	}

	void Update () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && idle) {
			
			IdleToMove ();
			IdleToEmpty ();
		}

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && Game_Controller.playerHealth == 0)
			ExitState ("dead");
	}

	void IdleToMove () {

		if (Input.GetButtonDown ("Horizontal") || Input.GetButtonDown ("Vertical"))
			ExitState ("move");
	}

	void IdleToEmpty () {
	
		if (Game_Controller.playerEnergy == 0)
			ExitState ("empty");
	}
}
