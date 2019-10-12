using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	public Game_Controller gameController;
	private Player_States playerState;

	public int speed;
	public int horizontal;
	public int vertical;
	public string direction;
	public bool turboMode;

	void OnEnable () {

		if (gameController == null)
			gameController = GameObject.Find("Game Controller").GetComponent <Game_Controller> ();

		if (playerState == null)
			playerState = gameObject.GetComponentInParent<Player_States> ();

		speed = 1;
		turboMode = false;
	}

	void Update () {

		if (gameController.currentState == Game_Controller.Game_State.Playing_State) {

			if (Input.GetButtonDown ("Secondary"))
				turboMode = !turboMode;
			
			if (playerState.currentState == Player_States.Player_State.Move_State) {

				GetDirections ();
			}
		}
	}

	void GetDirections () {

		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");

		if (Input.GetButtonDown ("Horizontal"))
			direction = "Horizontal";
		else if (Input.GetButtonDown ("Vertical"))
			direction = "Vertical";
		else if (Input.GetButtonUp ("Horizontal") && Input.GetButton ("Vertical"))
			direction = "Vertical";
		else if (Input.GetButtonUp ("Vertical") && Input.GetButton ("Horizontal"))
			direction = "Horizontal";
		
		switch (direction) {

			case ("Horizontal"):
				Move (horizontal, 0);
				Rotate (horizontal, 0);
				break;
			case ("Vertical"):
				Move (0, vertical);
				Rotate (0, vertical);
				break;
		}
	}

	void Move (int x, int y) {

		if (turboMode)
			speed = 2;
		else
			speed = 1;

		transform.Translate(x * 0.05f * speed, y * 0.05f * speed, Time.deltaTime, Space.World);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}

	void Rotate (int x, int y) {

		if (x < 0)
			transform.eulerAngles = new Vector3(0, 0, 0);

		if (x > 0)
			transform.eulerAngles = new Vector3(0, 0, 180);

		if (y > 0)
			transform.eulerAngles = new Vector3(0, 0, -90);

		if (y < 0)
			transform.eulerAngles = new Vector3(0, 0, 90);
	}
}
