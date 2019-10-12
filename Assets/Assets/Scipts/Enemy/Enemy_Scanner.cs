using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scanner : MonoBehaviour {

	private Game_Controller gameController;

	public GameObject target;
	public Transform gunPosition;
	public bool targetAquired;

	float distance = 10;
	float arc = 45f;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		StartCoroutine ("GetTarget");
		targetAquired = false;
	}

	void Update () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && target != null) {
			
			if (CanSee (target)) {

				targetAquired = true;

			} else {
			
				targetAquired = false;
			}
		}
	}

	IEnumerator GetTarget () {
	
		yield return new WaitForSeconds (0.1f);
		target = GameObject.Find("Player(Clone)");
	}

	public bool CanSee (GameObject target) {

		Vector3 startPosition = gunPosition.position; // start just ahead of self so to not hit self

		if (Vector3.Distance(startPosition, target.transform.position) < distance) {

			// enemy is within distance
			Vector3 forward = transform.TransformDirection(-Vector3.right) * distance;
			Vector3 targetDir = target.transform.position - startPosition;
			float angle = Vector3.Angle(targetDir, forward);

			if (angle < arc) {

				//within field of view
				RaycastHit2D hit = Physics2D.Raycast(startPosition, forward);
				Debug.DrawRay(startPosition, forward, Color.green);

				if (hit.transform != null) {
					
					//not blocked by walls or whatnot, aimed directly at target
					if (hit.collider.transform.parent.name == target.name) {

						Debug.DrawRay (startPosition, forward, Color.red);
						return true;
					} else if (hit.collider.transform.parent.name != target.name) {
					
						return false;
					}
				}
			}
		}

		return false;
	}
}
