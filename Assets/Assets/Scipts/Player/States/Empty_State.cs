using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty_State : MonoBehaviour {

	private Game_Controller gameController;
	private Player_States playerStates;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		//get the Game_Controller script
		if (playerStates == null) {
			playerStates = gameObject.GetComponent<Player_States> ();
		}
	}

	public void EnterState () {

		Debug.Log ("empty state");
	}

	public void ExitState (string nextState) {

		if (nextState == "idle") {

			playerStates.currentState = Player_States.Player_State.Idle_State;
			playerStates.ChangeState ();

		} else if (nextState == "dead") {

			playerStates.currentState = Player_States.Player_State.Dead_State;
			playerStates.ChangeState ();
		}
	}

	void Update () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && playerStates.currentState == Player_States.Player_State.Empty_State) {
		
			IdleToEmpty ();
		}

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && Game_Controller.playerHealth == 0)
			ExitState ("dead");
	}

	void IdleToEmpty () {

		if (Game_Controller.playerEnergy != 0)
			ExitState ("idle");
	}
}
