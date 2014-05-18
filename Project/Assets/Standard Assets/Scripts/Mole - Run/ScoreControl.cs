using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScoreControl : MonoBehaviour {
	
	public GUISkin playSkin;
	public GUISkin replaySkin;
	public GUISkin scoreSkin;
	public GUISkin menuSkin;
	private TimerControl timerControl;
	private MasterMoleControl masterMoleControl;
	private bool showScore;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;
	private int scoreCount;

	// Use this for initialization
	void Awake () {
		timerControl = GameObject.Find ("Timer").GetComponent<TimerControl> ();
		if (Application.loadedLevelName == "Whack-A-Mole") {
			masterMoleControl = GameObject.Find ("Master Mole").GetComponent<MasterMoleControl> ();
		}
	}

	void Start() {
		showScore = false;
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * (float)0.10;
		cushionWidth = width * (float)0.10;
		scoreCount = 0;
	}

	// Update is called once per frame
	void Update () {
		if (timerControl.gameEnded) {
			showScore = true;
		}
		else {
			showScore = false;
		}
	}

	private void OnGUI () {
		if (showScore) {
			GUI.BeginGroup (new Rect(0, 0, width, height));
			GUI.Box (new Rect(cushionWidth*3, cushionHeight, width*(float)0.40, height*(float)0.80), "");
			GUI.BeginGroup (new Rect (cushionWidth*3, cushionHeight, width, height));
			GUI.skin = scoreSkin;
			GUI.Label (new Rect (cushionWidth*(float)1.3, cushionHeight/2, width, height), "SCORE");
			if (Application.loadedLevelName == "Whack-A-Mole") {
				scoreCount = masterMoleControl.totalHits * 100;
			}
			else {
				scoreCount = WallControl.wallScore;
			}
			GUI.Label (new Rect (cushionWidth*(float)1.4, cushionHeight*3, width, height), scoreCount.ToString());
			if (!DataContainer.isPlayMode) {
				GUI.skin = menuSkin;
				if (GUI.Button (new Rect (cushionWidth*(float)2.5, cushionHeight*(float)6.50, 100, 50), "BACK")) {
					if (Application.loadedLevelName == "Whack-A-Mole") {
						Application.LoadLevel ("TrainMenu");
					}
					else if (Application.loadedLevelName == "Run Run") {
						Application.LoadLevel ("TrainMenu2");
					}	
				}
				GUI.skin = replaySkin;
				if (GUI.Button (new Rect (cushionWidth*(float)0.75, cushionHeight*(float)6.50, 100, 50), "REPLAY")) {
					Application.LoadLevel (Application.loadedLevel);
				}
			}
			else if (DataContainer.gameOver) {
				GUI.skin = playSkin;
				if (GUI.Button (new Rect (cushionWidth*(float)1.8, cushionHeight*(float)6.50, 100, 50), "FINISH")) {
					Application.LoadLevel ("Menu");
				}
			}
			else {
				GUI.skin = playSkin;
				if (GUI.Button (new Rect (cushionWidth*1.8f, cushionHeight*(float)6.50, 100, 50), "CONTINUE")) {
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
