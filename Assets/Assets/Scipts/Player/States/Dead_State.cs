using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_State : MonoBehaviour {

	private Player_States playerStates;

	void OnEnable () {

		//get the Game_Controller script
		if (playerStates == null) {
			playerStates = gameObject.GetComponent<Player_States> ();
		}
	}

	public void EnterState () {

		Debug.Log ("dead state");
	}

	public void ExitState () {

//		playerStates.currentState = Player_States.Player_State.Idle_State;
//		playerStates.ChangeState ();
	}
}
