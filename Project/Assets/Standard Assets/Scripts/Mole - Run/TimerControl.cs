// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

// shows the GUI in the game scene for testing purposes
[ExecuteInEditMode]
public class TimerControl : MonoBehaviour {

	// public and private variables needed
	// in order to showcase the timer of the minigame
	public static bool gameEnded = false;
	public GUIText timerText;
	private float count;
	private int timerCount;
	private string text;

	// Start ()
	void Start () {
		count = 30;
		timerCount = (int)count;
		timerText.text = count.ToString (); 
	}
	
	// Update ()
	void Update () {
		// while the game is in session update the timerCount to display
		// the seconds left in the minigame
		if (!gameEnded) {
			count -= Time.deltaTime;
			timerCount = (int)count;
			timerText.text = timerCount.ToString();
			if (count >= 0) {
				gameEnded = false;
			}
			// end the time early if the player loses a life in "Play Mode"
			// the player ONLY has the timer in "Train Mode"
			else {
				KillBallControl.ballMove = false;
				RunPlayerControl.ballHit = true;
				gameEnded = true;
			}
			if (MoleControl.lostLifeGO) {
				gameEnded = true;
			}
			if (RunPlayerControl.ballHit) {
				gameEnded = true;
			}
		}
		else {
			// reset the time if use wants to replay a level
			count = 30;
		}
	}
}
