using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

	public Game_Controller gameController;

	public GameObject enemy;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		Invoke ("SpawnEnemy", 0.5f);
	}

	void SpawnEnemy () {
	
		if (gameController.currentState == Game_Controller.Game_State.Playing_State)
			Instantiate (enemy, new Vector3 (0, 4, 0), Quaternion.identity, gameObject.transform);
	}
}
