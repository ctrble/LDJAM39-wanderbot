using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_State : MonoBehaviour {

	private Game_Controller gameController;
	private Player_States playerStates;

	private bool move;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		if (playerStates == null) {
			playerStates = gameObject.GetComponent<Player_States> ();
		}
	}

	public void EnterState () {

//		Debug.Log ("move state");
		move = true;
	}

	public void ExitState (string nextState) {

		if (nextState == "idle") {

			move = false;
			playerStates.currentState = Player_States.Player_State.Idle_State;
			playerStates.ChangeState ();

		} else if (nextState == "dead") {

			move = false;
			playerStates.currentState = Player_States.Player_State.Dead_State;
			playerStates.ChangeState ();
		}
	}

	void Update () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && move)
			MoveToIdle ();

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && move && Game_Controller.playerEnergy == 0)
			ExitState ("idle");

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && move && Game_Controller.playerHealth == 0)
			ExitState ("dead");
	}

	void MoveToIdle () {

		if (!Input.GetButton ("Horizontal") && !Input.GetButton ("Vertical"))
			ExitState ("idle");
	}

//	void MoveToDead () {
//
//		if (Game_Controller.playerHealth == 0)
//			ExitState ("dead");
//	}
}
