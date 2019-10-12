using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing_State : MonoBehaviour {

	private Game_Controller gameController;

	void OnEnable () {

		//get the Game_Controller script
		if (gameController == null) {
			gameController = gameObject.GetComponent<Game_Controller> ();
		}

		//subscribe to this delegate
//		Ball_Controller.onGoal += GetPoints;
	}

	public void EnterState () {

//		Debug.Log ("playing state");
	}

	public void ExitState () {

		gameController.currentState = Game_Controller.Game_State.Pause_State;
		gameController.ChangeState ();
	}

	void Update () {

		if (Input.GetButtonDown("Pause")) {

			ExitState ();
		}
	}


//	void OnDisable () {
//
//		//subscribe is up top!!!
//		//unsubscribe to this delegate
//		Laser_Controller.onHit -= GetPoints;
//	}
}


//public delegate void GoalAction(GameObject keepOwner); //send GameObject info with this event
//public static event GoalAction onGoal;

//void OnTriggerEnter2D(Collider2D other) {
//
//	if (other.tag == "Inside Keep") {
//
//		if (null != onGoal) {
//
//			//currently broadcasts to Game_Management_Controller and Ball_Removal_Controller
//			keepOwner = other.transform.parent.gameObject;
//			onGoal (keepOwner); //trigger event and send GameObject info
//		}
//	}
//}