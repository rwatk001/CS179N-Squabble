// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class WallControl : MonoBehaviour {

	// public and private variables needed
	// to dictate the actions of the obstacles
	// this implies both the walls and the sheep
	public bool hitWall;
	public static int wallScore = 0;
	private bool once;

	// Start ()
	void Start () {
		hitWall = false;
		once = true;
	}

	// Update ()
	// handles the destruction of the prefabs 
	// this destroys the game object once the player passes it
	// destroying the game object allows the game to run more efficiently
	void Update() {
		// uncomment for player based score otherwise the objects will be destroyed 
		// from the kill ball position
		if (GameObject.Find ("Kill Ball").transform.position.z > transform.position.z+10.0f) {
		////if (GameObject.Find ("Player").transform.position.z > transform.position.z+10.0f) {
			// score system based on how many obstacles you manage to get by
			// ScoreControl script access this variable to display the score for the mini game
			if (this.transform.name == "Sheep(Clone)" || this.transform.name == "Portal(Clone)") {
				SpawnWallControl.first = true;
			}

			if (this.transform.name != "Sheep" || this.transform.name != "Portal") {
				Destroy(gameObject);
			}
		}

		// increment the score for each obstacle wall the player successfully passes
		// only count each wall obstacle as one point
		if (GameObject.Find ("Player").transform.position.z > transform.position.z+10.0f && once) {
			if (this.transform.name != "Sheep(Clone)" && this.transform.name != "Portal(Clone)") {
				++wallScore;
				++DataContainer.finalScore;
				++TimerControl.scoreCount;
			}
			once = false;
		}
	}
}
