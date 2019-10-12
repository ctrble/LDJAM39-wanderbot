using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_State : MonoBehaviour {

	private Game_Controller gameController;

	public GameObject pauseMenu;

	void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = gameObject.GetComponent<Game_Controller> ();
		}
	}

	public void EnterState () {

		Debug.Log ("pause state");
		pauseMenu.SetActive (true);
	}

	public void ExitState (string nextState) {

		if (nextState == "continue") {
		
			pauseMenu.SetActive (false);
			gameController.currentState = Game_Controller.Game_State.Playing_State;
			gameController.ChangeState ();

		} else if (nextState == "quit") {
		
			pauseMenu.SetActive (false);
			gameController.currentState = Game_Controller.Game_State.End_State;
			gameController.ChangeState ();
		}
	}

	public void ContinueGame () {

		ExitState ("continue");
	}

	public void QuitGame () {

		ExitState ("quit");
	}

	void Update () {

//		if (Input.GetButtonDown("Pause")) {
//
//			ExitState ();
//		}
	}
}
