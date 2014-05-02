using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScoreControl : MonoBehaviour {

	public GameObject timerObject;
	public GameObject moleObject;
	public GUISkin playSkin;
	public GUISkin replaySkin;
	public GUISkin scoreSkin;
	private TimerControl timerControl;
	private MasterMoleControl masterMoleControl;
	private bool showScore;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;
	private int helpCount;

	// Use this for initialization
	void Awake () {
		timerControl = timerObject.GetComponent<TimerControl> ();
		masterMoleControl = moleObject.GetComponent<MasterMoleControl> ();
	}

	void Start() {
		showScore = false;
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * (float)0.10;
		cushionWidth = width * (float)0.10;
		helpCount = 0;
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
			helpCount = masterMoleControl.totalHits * 100;
			GUI.Label (new Rect (cushionWidth*(float)1.4, cushionHeight*3, width, height), helpCount.ToString());
			GUI.skin = playSkin;
			if (GUI.Button (new Rect (cushionWidth*(float)2.5, cushionHeight*(float)6.50, 100, 50), "CONTINUE")) {
				Application.LoadLevel ("Frogger");
			}
			GUI.skin = replaySkin;
			if (GUI.Button (new Rect (cushionWidth*(float)0.75, cushionHeight*(float)6.50, 100, 50), "REPLAY")) {
				Application.LoadLevel ("Whack-A-Mole_v1");
			}
			GUI.EndGroup ();
			GUI.EndGroup ();
		}
	}
}
