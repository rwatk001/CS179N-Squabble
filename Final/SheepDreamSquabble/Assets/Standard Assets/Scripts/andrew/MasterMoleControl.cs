using UnityEngine;
using System.Collections;

public class MasterMoleControl : MonoBehaviour {

	// public and private variables needed
	// to count the number of points a player achieves
	public int totalHits;
	private MoleControl moleControl;
	private bool scoreUpdate;

	// Start ()
	void Start () {
		scoreUpdate = false;
	}
	
	// Update ()
	void Update () {
		// waits till the game is done
		if (TimerControl.gameEnded && totalHits == 0) {
			scoreUpdate = true;
		}
		else {
			scoreUpdate = false;
		}
		// cycles through all the child objects, in this instance, all
		// the mole objects and counts how many EACH of them has been hit
		// this determines your score
		if (scoreUpdate) {
			foreach (Transform child in transform) {
				moleControl = child.gameObject.GetComponent<MoleControl>();
				totalHits += moleControl.numHits;
			}
			scoreUpdate = false;
		}
	}
}
