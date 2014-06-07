// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class KillBallControl : MonoBehaviour {

	// public and private variables needed
	// to control the kill ball's activation and movement
	public static bool ballMove = false;
	private float ballSpeed;

	// Start ()
	// handles the speed at which the kill ball moves at
	void Start () {
		ballSpeed = 25f;
	}
	
	// FixedUpdate ()
	void FixedUpdate () {
		// the kill ball activates once the player has a headstart
		// this variable is also in control of when the kill ball moves
		if (ballMove && SplashScreen.gameGO) { 
			this.transform.Translate (transform.forward * ballSpeed * Time.deltaTime);
		}
	}	
}
