using UnityEngine;
using System.Collections;

public class SpawnWallControl : MonoBehaviour {
	
	public Rigidbody wall;
	public GameObject player;
	public GameObject travelSheep;
	public GameObject portal;
	public static bool obstacleReady;
	public static bool first;
	private float loc;
	private float alongX;
	private float alongZ;
	private float originPositionZ;
	private float distance;
	private int switcher;
	private Vector3 position;
	private Quaternion rotation;
	private int random;
	private float counter;
	private float counterEnd;
	private bool extraBoolean;
	
	void Start () {
		loc = 0;
		distance = 30;
		obstacleReady = false;
		first = true;
		counter = 0.0f;
		counterEnd = 0.55f;
		extraBoolean = true;
	}

	// Update ()
	// randomly chooses to either spawn sheep obstacles or wall obstacles
	void Update () {
		random = Random.Range (1, 11);
		CustomWait ();
		if (random <= 2) {
			sheepSpawn ();
		}
		else {
			wallSpawn ();
		}
	}

	// the goal is to have sheep spawn on the ground plane that forces the player
	// to jump. This is will add to the reflex portion of my game
	public void sheepSpawn () {
		// the purpose of the 'first' boolean is to make the sheep move in a single line in the
		// x direction
		if (obstacleReady) {
			if (first) {
				originPositionZ = player.transform.position.z+30;
				Instantiate (portal, new Vector3 (115.79f, 0.0f, originPositionZ), Quaternion.Euler (90.0f, 0.0f, 0.0f));
				Instantiate (portal, new Vector3 (136.14f, 0.0f, originPositionZ), Quaternion.Euler (90.0f, 0.0f, 0.0f));
				first = false;
				alongX = -2.0f;
			}
			// this block of code handles the spawning of the sheep as an obstacle
			if (116.0f + alongX <= 135.0f) {
				alongX += 2.0f;
				position = new Vector3 (116.0f + alongX, 0.8f, originPositionZ);
				rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				Instantiate (travelSheep, position, rotation);
			}
		}
	}

	public void CustomWait() {
		if (counter <= counterEnd) {
			counter += Time.deltaTime;
		}
		else {
			counter = 0;
			extraBoolean = true;
		}
	}

	// function to handle the wall spawning
	public void wallSpawn () {
		// randomly spawns a wall along the ground plane
		loc = Random.Range (121.0f, 131.0f);
		// instantiates the wall 
		// it is important to remember these coordinates are hand pick to avoid the
		// the player from being stuck and glitched
		// these coordinates always gives the user a way out
		if (extraBoolean) {
			if (Random.Range (0, 35) <= Random.Range (0, 35) && !RunPlayerControl.wallHit && !RunPlayerControl.ballHit && obstacleReady) {
				Instantiate (wall, new Vector3(loc, 0.0f, player.transform.position.z+distance), Quaternion.identity);
			}
			extraBoolean = false;
		}
	}
}