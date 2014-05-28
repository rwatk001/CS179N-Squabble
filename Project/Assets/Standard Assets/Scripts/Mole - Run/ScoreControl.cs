// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

// shows the GUI on game scene for testing purposes
[ExecuteInEditMode]
public class ScoreControl : MonoBehaviour {

	// public and private variables needed
	// to calculate and display the right score for each game and situation
	public GUISkin playSkin;
	public GUISkin replaySkin;
	public GUISkin scoreSkin;
	public GUISkin menuSkin;
	private MasterMoleControl masterMoleControl;
	private bool showScore;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;
	private int scoreCount;

	// Awake ()
	void Awake () {
		// specific to the Whack-A-Mole game
		// access MasterMoleScript which calculates score there 
		// and displays score in this script
		if (Application.loadedLevelName == "Whack-A-Mole") {
			masterMoleControl = GameObject.Find ("Master Mole").GetComponent<MasterMoleControl> ();
		}
	}

	//Start ()
	void Start() {
		showScore = false;
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * (float)0.10;
		cushionWidth = width * (float)0.10;
		scoreCount = 0;
	}

	// Update ()
	void Update () {
		// this script has been modified to be used with my
		// teammates other minigames as well
		// showScore is the variable that access the user to the game over screen
		if (TimerControl.gameEnded || FroggerStart.froggerDone) {
			showScore = true;
		}
		else {
			showScore = false;
		}
	}

	// reloadReset() is a master reset. It proves as a extra layer of 
	// protection against all the static variables that do not get 
	// reset during the game modes. It accesses and resets all the 
	// important static variables across the minigames
	public static void reloadReset () {
		FroggerStart.froggerDone = false;
		FroggerPlayer.busHit = false;
		MoleControl.lostLifeGO = false;
		RunPlayerControl.wallHit = false;
		RunPlayerControl.ballHit= false;
		KillBallControl.ballMove = false;
		WallControl.wallScore = 0;
		TimerControl.gameEnded = false;
	}

	private void OnGUI () {
		if (showScore) {
			GUI.BeginGroup (new Rect(0, 0, width, height));
			GUI.Box (new Rect(cushionWidth*3, cushionHeight, width*(float)0.40, height*(float)0.80), "");
			GUI.BeginGroup (new Rect (cushionWidth*3, cushionHeight, width, height));
			GUI.skin = scoreSkin;
			GUI.Label (new Rect (cushionWidth*(float)1.3, cushionHeight/2, width, height), "SCORE");
			// determines which score is going to be displayed
			// it will either be the final score when you run out of lives or
			// an individual score based on the game you just played
			if (DataContainer.gameOver) {
				scoreCount = DataContainer.finalScore;
			}
			else if (Application.loadedLevelName == "Whack-A-Mole") {
				scoreCount = masterMoleControl.totalHits * 100;
				DataContainer.finalScore += scoreCount;
			}
			else if (Application.loadedLevelName == "Frogger") {
				scoreCount = FroggerPlayer.score;
				DataContainer.finalScore += scoreCount;
			}
			else {
				scoreCount = WallControl.wallScore;
				DataContainer.finalScore += scoreCount;
			}
			// "Train Mode" allows you to go back and choose other levels to practice
			// before taking on "Play Mode"
			GUI.Label (new Rect (cushionWidth*(float)1.4, cushionHeight*3, width, height), scoreCount.ToString());
			if (!DataContainer.isPlayMode) {
				GUI.skin = menuSkin;
				if (GUI.Button (new Rect (cushionWidth*(float)2.5, cushionHeight*(float)6.50, 100, 50), "BACK")) {
					reloadReset ();
					if (Application.loadedLevelName == "Whack-A-Mole") {
						Application.LoadLevel ("TrainMenu");
					}
					else if (Application.loadedLevelName == "Run Run") {
						Application.LoadLevel ("TrainMenu2");
					}
					else if (Application.loadedLevelName == "Frogger") {
						Application.LoadLevel ("TrainMenu");
					}	
				}
				GUI.skin = replaySkin;
				// "Train Mode" also gives you the option to replay the level at the end
				// for any reason
				if (GUI.Button (new Rect (cushionWidth*(float)0.75, cushionHeight*(float)6.50, 100, 50), "REPLAY")) {
					reloadReset ();	
					Application.LoadLevel (Application.loadedLevel);
				}
			}
			// displays the final score and reverts you back to the main title screen
			else if (DataContainer.gameOver) {
				GUI.skin = playSkin;
				if (GUI.Button (new Rect (cushionWidth*(float)1.8, cushionHeight*(float)6.50, 100, 50), "FINISH")) {
					reloadReset ();
					DataContainer.life = 3;
					DataContainer.finalScore = 0;
					Application.LoadLevel ("Menu");
				}
			}
			// part of "Play Mode" that you can only move forward
			// displays the right score and the next level is predetermined by the DataContainer script
			else {
				GUI.skin = playSkin;
				if (GUI.Button (new Rect (cushionWidth*1.8f, cushionHeight*(float)6.50, 100, 50), "CONTINUE")) {
					reloadReset ();
					if (Application.loadedLevel == DataContainer.level_1) {
						Application.LoadLevel (DataContainer.level_2);
					}
					else if (Application.loadedLevel == DataContainer.level_2) {
						Application.LoadLevel (DataContainer.level_3);
					}
					else if (Application.loadedLevel == DataContainer.level_3) {
						Application.LoadLevel (DataContainer.level_4);
					}
					else if (Application.loadedLevel == DataContainer.level_4) {
						Application.LoadLevel (DataContainer.level_5);
					}
					else if (Application.loadedLevel == DataContainer.level_5) {
						DataContainer.AssignLevel ();
						Application.LoadLevel (DataContainer.level_1);
					}
				}
			}
			GUI.EndGroup ();
			GUI.EndGroup ();
		}
	}
}