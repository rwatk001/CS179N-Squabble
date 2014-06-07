// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class RunPlayerControl : MonoBehaviour {

	// public and private variables needed
	// to control the player
	public GameObject player;
	public GameObject killBall;
	public static bool ballHit = false;
	public static bool wallHit = false;
	private float moveHorizontal;
	private Vector3 newPosition;
	private Vector3 playerOrigin;
	private Vector3 killBallOrigin;
	private Vector3 tmpPosition;
	private float gravity;
	private float runningSpeed;
	private float jump;
	private bool beginJump;
	private bool descent;
	private bool sheepHit;

	// Start ()
	void Start () {
		gravity = 30.0f;
		runningSpeed = 30.0f;
		jump = 5.0f;
		tmpPosition = Vector3.zero;
		beginJump = false;
		descent = false;
		sheepHit = false;
		playerOrigin = transform.position;
		killBallOrigin = killBall.transform.position;
	}

	// this checkPosition () keeps the player on the plane
	// it acts as a boundary check for only the horizontal axis
	public void checkPosition () {
		if (newPosition.x <= 116.5f) {
			newPosition.x = 116.5f;
		}
		if (newPosition.x >= 135.0f) {
			newPosition.x = 135.0f;
		}
	}

	// Update ()
	void Update () {
		if (!ballHit && SplashScreen.gameGO && !Input.GetMouseButton(1)) {
			// the goal is for the player to follow the mouse cursor 
			// its movement is limited to left and right because the forward is automatic and
			// dicatated y the obstacles
			Plane playerPlane = new Plane (Vector3.up, transform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float hit;
			// I am using Plane.Raycast so if there is no plane then this if statement fails
			// in response I set the interpolation coordinate to the previous position 
			// in hopes of smooth;y translating the player
			if (playerPlane.Raycast (ray, out hit) && !ballHit) {
				newPosition = ray.GetPoint (hit);
			}
			else {
				newPosition = tmpPosition;
			}
			checkPosition ();
			// on a mouse click the player
			// is suppose to jump
			// this is another way to bypass the obstacles in the game
			if (Input.GetMouseButtonDown (0)) {
				beginJump = true;
				sheepHit = false;
			}
			// this handles the actually translation of the player object as it jumps
			if (beginJump && !descent) {
				tmpPosition.y += gravity * Time.deltaTime;
				newPosition.y = tmpPosition.y;
				if (newPosition.y >= jump) {
					descent = true;
				}
			}
			else if (!beginJump) {
				newPosition.y = 0.0f;
			}
			else if (descent) {
				//tmpPosition.y -= gravity * Time.deltaTime;
				//newPosition.y = tmpPosition.y;
				newPosition.y -= gravity * Time.deltaTime;
				if (newPosition.y <= 0.0f) {
					newPosition.y = 0.0f;
					beginJump = false;
					descent = false;
				}
			}
			// the z-axis is the player moving forward
			// depending if the player hit an obstacle or not the
			// player automatically runs forward
			// time also plays a part in the player movement
			if (!wallHit && !sheepHit && !TimerControl.gameEnded) {
				newPosition.z = transform.position.z + (runningSpeed * Time.deltaTime);
			}
			else {
				newPosition.z = transform.position.z;
			}
			// interpolate the transforms position to the mouse cursor's position
			tmpPosition = newPosition;
			float journey = 0.75f / Vector3.Distance (transform.position, newPosition);
			transform.position = Vector3.Lerp (transform.position, newPosition, journey);
		}
	}

	// this handles all the collisions detected by the player
	void OnTriggerEnter (Collider trigger) {
		// if it hit a wall the stop the player's z movement
		// this strands the player in the same spot until he dies or moves out the way
		if (trigger.gameObject.tag == "Wall") {
			wallHit = true;
		}
		else if (trigger.gameObject.tag == "Sheep") {
			sheepHit = true;
		}
		// the turn events trigger when the obstacles spawn
		else if (trigger.gameObject.tag == "Turn") {
			KillBallControl.ballMove = true;
			if (SpawnWallControl.obstacleReady) {
				SpawnWallControl.obstacleReady = false;
			}
			else {
				SpawnWallControl.obstacleReady = true;
			}
		}
		// aside from obstacles the player must make haste because there is a kill ball element
		// the kill ball hunts you down and if it catches up to you then a life is lost
		// in "Play Mode" this will continue the game but in "Train Mode" either the 
		// kill ball will be inert or sends you to the origin
		else if (trigger.gameObject.tag == "Kill Ball" && KillBallControl.ballMove) {
			if (DataContainer.isPlayMode) {
				ballHit = true;
				//KillBallControl.ballMove = false;
				transform.Translate(new Vector3(0.0f, -10.0f, 0.0f));
				--DataContainer.life;
			}
			else {
				playerReset ();
				Destroy (GameObject.Find ("Portal(Clone)"));
				Destroy (GameObject.Find ("Sheep(Clone)"));
				Destroy (GameObject.Find ("Rocks(Clone)"));
			}
		}
		// this handles all the pathways and makes sure the player does
		// not cheat and stays on the path that it intends the player to take
		// this is the only part where the player can lose a life moving forward
		else if (trigger.gameObject.tag == "Empty") {
			if (DataContainer.isPlayMode) {
				ballHit = true;
				transform.Translate(new Vector3(0.0f, -10.0f, 0.0f));
				--DataContainer.life;
			}
			else {
				playerReset();
			}
		}
	}

	// handles the player continue its movement when it clears an obstacle
	void OnTriggerExit (Collider trigger) {
		if (trigger.gameObject.tag == "Wall") {
			wallHit = false;
		}
	}

	// resets certain variables for "Train Mode" that way the player
	// can continue playing without worrying about lives
	public void playerReset() {
		SpawnWallControl.obstacleReady = false;
		transform.position = playerOrigin;
		killBall.transform.position = killBallOrigin;
		KillBallControl.ballMove = false;
		wallHit = false;
		sheepHit = false;
		ballHit = false;
	}
}
