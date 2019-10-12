using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_State : MonoBehaviour {

	private Game_Controller gameController;

	void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = gameObject.GetComponent<Game_Controller> ();
		}
	}

	public void EnterState () {

		Debug.Log ("end state");
	}

	public void ExitState () {

		//take to main menu
		gameController.currentState = Game_Controller.Game_State.Pause_State;
		gameController.ChangeState ();
	}
}
