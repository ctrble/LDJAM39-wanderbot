using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Controller : MonoBehaviour {

	public Game_Controller gameController;

	public Animator laserAnimator;

	public delegate void HitAction(GameObject hitObject); //send GameObject info with this event
	public static event HitAction onHit;

	public int speed;
	public bool go;
	public bool armed;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		speed = 5;
		go = true;
		armed = false;
		StartCoroutine ("ArmLaser");
		StartCoroutine ("ExpireLaser");
	}

	void Update () {
	
		if (gameController.currentState == Game_Controller.Game_State.Playing_State && go)
			transform.Translate (-Vector3.right * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (armed) {
		
			laserAnimator.SetTrigger ("hit");
			StartCoroutine ("Splatter");
			onHit (other.gameObject); //trigger event and send GameObject info
		}
	}

	IEnumerator ArmLaser () {

		yield return new WaitForSeconds(0.1f);
		armed = true;
	}

	IEnumerator Splatter () {
	
		yield return new WaitForSeconds(0.1f);
		go = false;
	}

	IEnumerator ExpireLaser () {

		yield return new WaitForSeconds(5);
		RemoveLaser ();
	}

	void RemoveLaser () {

		Destroy (gameObject);
	}
}
