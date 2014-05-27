using UnityEngine;
using System.Collections;

public class TurnControl : MonoBehaviour {

	public GameObject player;
	public GameObject killBall;
	public static int turnCount = 0;
	public static int ballCount = 0;

	void MoveCenter () {
		if (ballCount == 0) {
			killBall.GetComponent<SphereCollider>().center = new Vector3(0.0f, -1.5f, -0.2f);
		}
		else if (ballCount == 1) {
			killBall.GetComponent<SphereCollider>().center = new Vector3(-0.1f, -1.5f, 0.0f);
		}
		else if (ballCount == 2) {
			killBall.GetComponent<SphereCollider>().center = new Vector3(0.5f, -1.5f, 0.0f);
		}
		else {
			killBall.GetComponent<SphereCollider>().center = new Vector3(0.5f, -1.5f, -0.2f);
		}
	}

	void OnTriggerEnter (Collider trigger) {
		if (transform.name == "Turn") {
			if (trigger.gameObject.tag == "Player") {
				player.transform.Rotate (new Vector3(0, -90, 0));
				++turnCount;
				turnCount = turnCount % 4;
				if (turnCount == 1) {
					KillBallControl.ballMove = true;
				}
			}
	}
		if (transform.name == "BallTurn") {
			if (trigger.gameObject.tag == "Kill Ball") {
				killBall.transform.Rotate (new Vector3(0, -90, 0));
				++ballCount;
				ballCount = ballCount % 4;
				MoveCenter ();
			}
		}
	}
}
