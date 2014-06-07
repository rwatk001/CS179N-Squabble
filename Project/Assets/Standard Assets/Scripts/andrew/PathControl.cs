// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class PathControl : MonoBehaviour {

	// public and private variables needed
	// to control the pathways and the variations 
	public GameObject path1;
	public GameObject path2;
	public GameObject path3;
	public GameObject path4;
	public GameObject path5;
	public GameObject path6;
	public GameObject path7;
	public GameObject path8;
	public GameObject path9;
	public GameObject path10;
	public GameObject path11;
	public GameObject path12;
	private int firstRand;
	private int secondRand;
	private int thirdRand;
	private int fourthRand;
	private int pathChoice1;
	private int pathChoice2;
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
		path7.renderer.enabled = false;
		path8.renderer.enabled = false;
		path9.renderer.enabled = false;
		path10.renderer.enabled = false;
		path11.renderer.enabled = false;
		path12.renderer.enabled = false;
		firstRand = Random.Range (1, 4);
		secondRand = Random.Range (1, 4);
		thirdRand = Random.Range (1, 3);
		fourthRand = Random.Range (1, 3);
		pathChoice1 = Random.Range (1, 3);
		pathChoice2 = Random.Range (1, 3);
		disappear = new Vector3 (0.0f, -50.0f, 0.0f);
	}
	
	// Update ()
	// the goal is to randomly select a path that the user must take
	// if they miss the path they lose a life
	// it adds complexity to the game and continues to test their reflexes
	// access the mesh renderer and box collider of the plane game objects
	void Update () {
		if (pathChoice1 == 1) {
			// clear the BoxColliders of the other pathways
			path10.GetComponent <BoxCollider> ().center = disappear;
			path11.GetComponent <BoxCollider> ().center = disappear;
			path12.GetComponent <BoxCollider> ().center = disappear;
			// handles the first set of paths which will be horizontal
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
		}
		else {
			// clear the BoxColliders of the other pathways
			path1.GetComponent <BoxCollider> ().center = disappear;
			path2.GetComponent <BoxCollider> ().center = disappear;
			path3.GetComponent <BoxCollider> ().center = disappear;
			// handles the next set of paths, which will be vertical
			if (thirdRand == 1) {
				path10.renderer.enabled = true;
				path12.renderer.enabled = true;
				path10.GetComponent <BoxCollider> ().center = disappear;
				path12.GetComponent <BoxCollider> ().center = disappear;
			}
			else {
				path11.renderer.enabled = true;
				path11.GetComponent <BoxCollider> ().center = disappear;
			}
		}
		if (pathChoice2 == 1) {
			// clear the BoxColliders of the other pathways
			path7.GetComponent <BoxCollider> ().center = disappear;
			path8.GetComponent <BoxCollider> ().center = disappear;
			path9.GetComponent <BoxCollider> ().center = disappear;
			// handles the second set of paths, which will be horizontal
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
		else {
			// clear the BoxColliders of the other pathways
			path4.GetComponent <BoxCollider> ().center = disappear;
			path5.GetComponent <BoxCollider> ().center = disappear;
			path6.GetComponent <BoxCollider> ().center = disappear;
			// handles the next set of paths, which will be vertical
			if (fourthRand == 1) {
				path7.renderer.enabled = true;
				path9.renderer.enabled = true;
				path7.GetComponent <BoxCollider> ().center = disappear;
				path9.GetComponent <BoxCollider> ().center = disappear;
			}
			else {
				path8.renderer.enabled = true;
				path8.GetComponent <BoxCollider> ().center = disappear;
			}
		}
	}
}
