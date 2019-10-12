using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : MonoBehaviour {

	private Game_Controller gameController;

	public Enemy_Scanner enemyScanner;
	public GameObject laser;
	public bool readyToShoot;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();
	
		if (enemyScanner == null)
			enemyScanner = gameObject.GetComponent <Enemy_Scanner> ();

		readyToShoot = false;

		InvokeRepeating ("Shooting", 1f, 1f);
	}

	void Update () {
	
//		if (enemyScanner.targetAquired) {
//
//			readyToShoot = true;
////			StartCoroutine ("Shoot");
//		}
	}

	void Shooting () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State && enemyScanner.targetAquired) {
			
			Instantiate (laser, transform.position, transform.rotation);
		}
	}

	IEnumerator Shoot () {

		yield return new WaitForSeconds (0.5f);

		if (readyToShoot) {
			Instantiate (laser, transform.position, transform.rotation);
//			readyToShoot = false;
		}

		yield return new WaitForSeconds (0.5f);
		readyToShoot = false;
	}

	void OnDisable () {

		CancelInvoke ();
	}
}

