using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_States : MonoBehaviour {

	//create an enum for the game states
	public enum Player_State {Idle_State, Move_State, Hurt_State, Dead_State, Empty_State}

	//variables for all the state scripts
	public Idle_State idleState;
	public Move_State moveState;
	public Dead_State deadState;
	public Empty_State emptyState;

	//variables to tell the script which state to use
	public Player_State currentState;

	//other controllers
	public GameObject gameController;

	//global variables

	void Awake () {

		//first, reference all of the state scripts
		idleState = GetComponent<Idle_State> ();
		moveState = GetComponent<Move_State> ();
		deadState = GetComponent<Dead_State> ();
		emptyState = GetComponent<Empty_State> ();

		//get prepping
		currentState = Player_State.Idle_State;

		//ready to go
		ChangeState ();
	}

	public void ChangeState () {

		//new state!
		switch (currentState) {
		case Player_State.Idle_State:
			idleState.EnterState ();
			break;
		case Player_State.Move_State:
			moveState.EnterState ();
			break;
		case Player_State.Dead_State:
			deadState.EnterState ();
			break;
		case Player_State.Empty_State:
			emptyState.EnterState ();
			break;
		}
	}
}
