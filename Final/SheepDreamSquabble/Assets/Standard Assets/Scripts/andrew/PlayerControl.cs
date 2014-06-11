// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// public and private variables
	// to store and update player control
	public GameObject player;
	public GameObject timerObject;
	private TimerControl timerControl;
	private Animator animator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 newPosition;
	private bool playerGO;
	private float counter;
	private float counterEnd;

	// Awake () called once. It gets the animator 
	// so I can access the animations through scripting
	void Awake() {
		animator = GetComponent<Animator> ();
		playerGO = false;
		counter = 0.0f;
		counterEnd = 1.5f;
	}

	// checkPosition () acts as a boundary check so the player 
	// does not go pass the obvious limits of the plane
	public void checkPosition () {
		if (newPosition.x <= -12.7f) {
			newPosition.x = -12.7f;
		}
		if (newPosition.x >= 12.5f) {
			newPosition.x = 12.5f;
		}
		if (newPosition.z <= -14.5f) {
			newPosition.z = -14.5f;
		}
		if (newPosition.z >= 10.0f) {
			newPosition.z = 10.0f;
		}
	}

	// a similiar function to JavaScripts
	// yield WaitForSeconds()
	// the main purpose is to give the player time to move first
	// at the beginning of the level
	public void CustomWait () {
		if (counter <= counterEnd) {
			counter += Time.deltaTime;
		}
		else {
			counter = 0;
			playerGO = true;
		}
	}

	// FixedUpdate ()
	void FixedUpdate () {
		if (SplashScreen.gameGO) {
			// essentially it gives the player time to
			// get ready before playing
			if (!playerGO) {
				CustomWait ();
			}
			// boolean checks to see if a sheep has hit the player
			// if it has not, then the player can move
			// in "Play Mode" the player usually loses a life but in
			// "Train Mode" the player is just stunned until sheep move
			if (playerGO) {
				if (!SheepFollow.sheepHitPlayer && !TimerControl.gameEnded) {
					// taken from example script from Unity3d documentation
					// modified slightly
					Plane playerPlane = new Plane(Vector3.up, transform.position);
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					float hit;
					if (playerPlane.Raycast (ray, out hit)) {
						// the purpose is to follow the mouse cursor
						newPosition = ray.GetPoint (hit);
						checkPosition ();
						transform.LookAt (newPosition);
						transform.Rotate (new Vector3(0.0f, 180.0f, 0.0f));
						if (Vector3.Distance (transform.position, newPosition) >= 2.0f) {
							float journey = 0.18f / Vector3.Distance (transform.position, newPosition);
							transform.position = Vector3.Lerp (transform.position, newPosition, journey);
						}
					}
				}

				// extra boolean check
				// accesses the animator and applies animation to player accordingly
				if (!TimerControl.gameEnded && !SheepFollow.sheepHitPlayer) {

					AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

					if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Idle 0") || stateInfo.nameHash == Animator.StringToHash("Base Layer.Attack 0")) {
						if (Input.GetMouseButtonDown(0)) {
							animator.SetBool ("hit", true);
						}
						else {
							animator.SetBool ("hit", false);
						}
					}
				}
			}
		}
	}

	// checks to see if there is a collision between
	// player and the sheep. Depending on the game
	// mode you either lose a life or get stunned
	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "Sheep") {
			if (DataContainer.isPlayMode) {
				--DataContainer.life;
				MoleControl.lostLifeGO = true;
				SheepFollow.sheepHitPlayer = true;
				SheepFollow.sheepGO = false;
			}
			else {
                trigger.audio.Play();
				playerGO = false;
			}
		}
	}

	// lets the player move again after being stunned
	void OnTriggerExit (Collider trigger) {
		if (trigger.gameObject.tag == "Sheep") {
			if (!DataContainer.isPlayMode) {
				SheepFollow.sheepHitPlayer = false;
				playerGO = true;
			}
		}
	}
}
