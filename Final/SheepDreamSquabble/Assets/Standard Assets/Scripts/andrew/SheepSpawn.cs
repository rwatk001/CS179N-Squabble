// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class SheepSpawn : MonoBehaviour {

	// public and private variables needed
	// to instantiate the sheep
	public GameObject sheep;
	public GameObject player;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	private bool spawnReady;
	private int numOfSheep;

	// Use this for initialization
	// Start() only called once
	void Start () {
		spawnReady = true;
		numOfSheep = 1;
	}
	
	// Update ()
	void Update () {
		// boolean ensures that the sheep are only spawned
		// once per level
		// there is a total of numSheep of sheeps on the playing field
		if (spawnReady) {
			for (int i = 0; i<numOfSheep; ++i) {
				// the goal is to spawn sheep away from the player
				// with a random rotation
				spawnRotation = Quaternion.Euler (0.0f, Random.Range (0.0f, 360.0f), 0.0f);
				spawnPosition = new Vector3 (Random.Range (-10.0f, 10.0f), 1.2f, Random.Range (-10.0f, 10.0f));
				while (Vector3.Distance (player.transform.position, spawnPosition) <= 4) {
					spawnPosition = new Vector3 (Random.Range (-10.0f, 10.0f), 1.3f, Random.Range (-10.0f, 10.0f));
				}
				Instantiate (sheep, spawnPosition, spawnRotation);
			}
			// boolean to ensure no more sheep spawn unnecessarily
			spawnReady = false;
		}
	}
}
