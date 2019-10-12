using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup_State : MonoBehaviour {

	private Game_Controller gameController;

	public GameObject playerController;
	public GameObject playerObject;
	public Vector3 playerSpawn;

	void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = gameObject.GetComponent<Game_Controller> ();
		}
	}

	public void EnterState () {

//		Debug.Log ("setup state");
		SetupGame ();
	}

	public void ExitState () {

		gameController.currentState = Game_Controller.Game_State.Playing_State;
		gameController.ChangeState ();
	}

	void SetupGame() {

		SpawnPlayer ();

		ExitState ();
	}

	void SpawnPlayer () {

		Instantiate (playerObject, playerSpawn, Quaternion.identity, playerController.transform);
	}
}
