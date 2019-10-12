using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

	//create an enum for the game states
	public enum Game_State {Setup_State, Playing_State, Pause_State, End_State}

	//variables for all the state scripts
	public Setup_State setupState;
	public Playing_State playingState;
	public Pause_State pauseState;
	public End_State endState;

	//variables to tell the script which state to use
	public Game_State currentState;

	//other controllers
//	public GameObject playerManager;
//	public GameObject ballManager;
//	public GameObject uiManager;
//	public UI_Controller uiController;

	//global variables
	//# of players (later get from player prefs)
	//points per player
	public static int playerEnergy;
	public static int playerHealth;

	void Awake () {

		//first, reference all of the state scripts
		setupState = GetComponent<Setup_State> ();
		playingState = GetComponent<Playing_State> ();
		pauseState = GetComponent<Pause_State> ();
		endState = GetComponent<End_State> ();

		//get prepping
		currentState = Game_State.Setup_State;

		//basic stats
		playerEnergy = 5;
		playerHealth = 5;

		//ready to go
		ChangeState ();
	}

	public void ChangeState () {

		//new state!
		switch (currentState) {
		case Game_State.Setup_State:
			setupState.EnterState ();
			break;
		case Game_State.Playing_State:
			playingState.EnterState ();
			break;
		case Game_State.Pause_State:
			pauseState.EnterState ();
			break;
		case Game_State.End_State:
			endState.EnterState ();
			break;
		}
	}

	void Update () {

		playerEnergy = Mathf.Clamp (playerEnergy, 0, 10);
		playerHealth = Mathf.Clamp (playerHealth, 0, 10);
	}
}
