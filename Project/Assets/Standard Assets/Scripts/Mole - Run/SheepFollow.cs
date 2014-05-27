// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class SheepFollow : MonoBehaviour {

	// public and private variables needed
	// to update the sheep
	public static bool sheepHitPlayer;
	public bool sheepGO;
	public GameObject player;
	private float sheepSpeed;
	private Vector3 movement;
	private Transform trans;
	private float counter;
	private float counterEnd;

	// Use this for initialization
	// Start () only called once
	void Start () {
		sheepSpeed = 3.5f;
		sheepGO = false;
		sheepHitPlayer = false;
		trans = player.transform;
		counter = 0;
		counterEnd = 2;
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
			sheepGO = true;
		}
	}
	
	// FixedUpdate ()
	void FixedUpdate () {
		CustomWait ();
		// only move the Instantiate objects and not the main prefab
		if (sheepGO && transform.name == "sheepFab(Clone)") {
			// the goal is to move the sheep towards the player as fast as sheepSpeed
			transform.LookAt (trans);
			if (Vector3.Distance(transform.position, trans.position) >= 1) {
				transform.position += transform.forward * sheepSpeed * Time.deltaTime;
			}
		}
	}

	// creates openings for the player to freely move
	// if sheeps collide then they randomly move towards a wall
	// this keeps the sheep from forming into one object in the game scene and
	// they are always constantly moving
	public Transform distraction (int n) {
		if (n == 1) {
			return GameObject.Find ("North Wall").transform;
		}
		else if (n == 2) {
			return GameObject.Find ("South Wall").transform;
		}
		else if (n == 3) {
			return GameObject.Find ("East Wall").transform;
		}
		else {
			return GameObject.Find ("West Wall").transform;
		}
	}

	// controls the target of the sheep
	// it is either the player or the walls depending on the situation
	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "Sheep") {
			trans = distraction (Random.Range (1, 5));
		}
		else if (trigger.gameObject.tag == "North Wall" || trigger.gameObject.tag == "South Wall" 
		         || trigger.gameObject.tag == "East Wall" || trigger.gameObject.tag == "West Wall")  {
			trans = player.transform;
		}
	}
}
