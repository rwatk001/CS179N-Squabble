using UnityEngine;
using System.Collections;

public class KillBallControl : MonoBehaviour {

	public static bool ballMove;
	private float ballSpeed;
	// Use this for initialization
	void Start () {
		ballMove = false;
		ballSpeed = 30f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ballMove) {
			if (TurnControl.ballCount == 0) {
				this.transform.Translate (transform.forward * ballSpeed * Time.deltaTime);
			}
			else if (TurnControl.ballCount == 1) {
				this.transform.Translate (-transform.right * ballSpeed * Time.deltaTime);
			}
			else if (TurnControl.ballCount == 2) {
				this.transform.Translate (-transform.forward * ballSpeed * Time.deltaTime);
			}
			else {
				this.transform.Translate (transform.right * ballSpeed * Time.deltaTime);
			}
		}
	}	
}
