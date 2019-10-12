using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

	private Game_Controller gameController;
	private Player_States playerState;

	public Animator tiresAnimator;
	public Animator bodyAnimator;
	public Animator energyAnimator;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		if (playerState == null)
			playerState = gameObject.GetComponentInParent<Player_States> ();
	}

	void Update () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State) {

			if (playerState.currentState == Player_States.Player_State.Move_State) {

				MoveTires ();
				MoveBody ();
				SetEnergy ();

			} else if (playerState.currentState != Player_States.Player_State.Move_State) {
			
				IdleTires ();
				IdleBody ();
				SetEnergy ();
			}
		}
	}

	void MoveTires () {

		tiresAnimator.SetBool ("move", true);
		tiresAnimator.SetBool ("idle", false);
	}

	void MoveBody () {

		bodyAnimator.SetBool ("move", true);
		bodyAnimator.SetBool ("idle", false);
	}

	void IdleTires () {

		tiresAnimator.SetBool ("move", false);
		tiresAnimator.SetBool ("idle", true);
	}

	void IdleBody () {

		bodyAnimator.SetBool ("move", false);
		bodyAnimator.SetBool ("idle", true);
	}

	void SetEnergy () {
	
		energyAnimator.SetInteger ("energy", Game_Controller.playerEnergy);
	}
}
