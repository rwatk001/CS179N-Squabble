using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TrainMenuList : MonoBehaviour {

	public GUISkin playSkin;
	public GUISkin replaySkin;
	public Texture2D boom;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * 0.1f;
		cushionWidth = width * 0.1f;
	}
	
	private void OnGUI () {
		GUI.BeginGroup (new Rect (0, 0, width, height));
		GUI.DrawTexture (new Rect (width/2-cushionWidth*1.5f, cushionHeight/20, boom.width, boom.height), boom);
		GUI.skin = playSkin;
		GUI.Label (new Rect (width/2-cushionWidth, cushionHeight+20, 500, 200), "MINIGAMES");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (width/2+5-cushionWidth, cushionHeight+10, 500, 200), "MINIGAMES");
		GUI.EndGroup ();
		GUI.skin = playSkin;
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2, 190, 35), "WHACK-A-MOLE")) {
			Application.LoadLevel ("Whack-A-Mole");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2+40, 190, 35), "COUNTING SHEEP")) {
			Application.LoadLevel ("BarrelBreaker");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2+80, 190, 35), "CROSSING STREET")) {
			//Application.LoadLevel ("Frogger");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2+120, 190, 35), "TOMATO TOSS")) {
			//Application.LoadLevel ("");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2+160, 190, 35), "ROCKET JUMP")) {
			Application.LoadLevel ("RocketJump");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2+200, 190, 35), "RUN MAN, RUN")) {
			Application.LoadLevel ("Run Run");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/2.0f, height/2+240, 190, 35), "BACK")) {
			Application.LoadLevel ("Menu");
		}
	}
}
