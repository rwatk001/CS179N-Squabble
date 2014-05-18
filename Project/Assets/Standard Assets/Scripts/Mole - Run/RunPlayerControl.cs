using UnityEngine;
using System.Collections;

public class RunPlayerControl : MonoBehaviour {

	public GameObject player;
	private float speed;
	public static bool ballHit = false;
	public static bool wallHit = false;
	private float moveHorizontal;
	private Vector3 movement;
	private Vector3 origin;
	private float runningSpeed;
	private float jump;
	private bool eastHit;
	private bool westHit;

	// Use this for initialization
	void Start () {
		//jump = 0.0f;
		speed = 10;
		runningSpeed = 150f;
		eastHit = false;
		westHit = false;
	}
	
	void FixedUpdate () {
		moveHorizontal = Input.GetAxis ("Horizontal");
		if (eastHit) {
			if (moveHorizontal > 0) {
				moveHorizontal = 0;
			}
		}
		else if (westHit) {
			if (moveHorizontal < 0) {
				moveHorizontal = 0;
			}
		}
		if (!wallHit) {
			movement = new Vector3 (moveHorizontal, 0.0f, runningSpeed * Time.deltaTime);
		}
		else {
			movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		}

		/*if (Input.GetKeyDown (KeyCode.Space)) {
			jump = 5f;
			movement = new Vector3 (moveHorizontal, jump * runningSpeed * Time.deltaTime, runningSpeed * Time.deltaTime);
			if (Input.GetKeyUp (KeyCode.Space)) {
				movement = new Vector3 (moveHorizontal, -jump * runningSpeed * Time.deltaTime, runningSpeed * Time.deltaTime);
			}
		}*/

		if (!ballHit) {
			player.transform.Translate (movement * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "Wall") {
			wallHit = true;
		}
		else if (trigger.gameObject.tag == "East Wall") {
			eastHit = true;
		}
		else if (trigger.gameObject.tag == "West Wall") {
			westHit = true;
		}
		else if (trigger.gameObject.tag == "Kill Ball" && KillBallControl.ballMove) {
			ballHit = true;
			KillBallControl.ballMove = false;
			transform.Translate(new Vector3(0.0f, -10.0f, 0.0f));
		}
	}

	void OnTriggerExit (Collider trigger) {
		if (trigger.gameObject.tag == "Wall") {
			wallHit = false;
		}
		else if (trigger.gameObject.tag == "East Wall") {
			eastHit = false;
		}
		else if (trigger.gameObject.tag == "West Wall") {
			westHit = false;
		}
	}
}
