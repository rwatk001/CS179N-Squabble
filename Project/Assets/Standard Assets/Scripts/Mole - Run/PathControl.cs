// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class PathControl : MonoBehaviour {

	// public and private variables needed
	// to control the pathways
	public GameObject path1;
	public GameObject path2;
	public GameObject path3;
	public GameObject path4;
	public GameObject path5;
	public GameObject path6;
	private int firstRand;
	private int secondRand;
	private Vector3 disappear;

	// Start ()
	void Start () {
		// originally turn off all paths
		// in the Update(), only turn on the renderer 
		// of the chosen path
		path1.renderer.enabled = false;
		path2.renderer.enabled = false;
		path3.renderer.enabled = false;
		path4.renderer.enabled = false;
		path5.renderer.enabled = false;
		path6.renderer.enabled = false;
		firstRand = Random.Range (1, 4);
		secondRand = Random.Range (1, 4);
		disappear = new Vector3 (0.0f, -50.0f, 0.0f);
	}
	
	// Update ()
	// the goal is to randomly select a path that the user must take
	// if they miss the path they lose a life
	// it adds complexity to the game and continues to test their reflexes
	// access the mesh renderer and box collider of the plane game objects
	void Update () {
		if (firstRand == 1) {
			path1.renderer.enabled = true;
			path1.GetComponent <BoxCollider> ().center = disappear;
		}
		else if (firstRand == 2) {
			path2.renderer.enabled = true;
			path2.GetComponent <BoxCollider> ().center = disappear;
		}
		else {
			path3.renderer.enabled = true;
			path3.GetComponent <BoxCollider> ().center = disappear;
		}
		if (secondRand == 1) {
			path4.renderer.enabled = true;
			path4.GetComponent <BoxCollider> ().center = disappear;
		}
		else if (secondRand == 2) {
			path5.renderer.enabled = true;
			path5.GetComponent <BoxCollider> ().center = disappear;
		}
		else {
			path6.renderer.enabled = true;
			path6.GetComponent <BoxCollider> ().center = disappear;
		}
	}
}
