﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	void Start () {

		player = player.transform.GetChild (0).gameObject;
		
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}
		
	void LateUpdate () {
		
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;
	}
}



