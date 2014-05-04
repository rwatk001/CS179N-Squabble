using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MenuControl : MonoBehaviour {

	public GUISkin menuSkin;
	public GUISkin playSkin;
	public GUISkin replaySkin;
	public Texture2D boom;
	public bool playMode;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * (float)0.10;
		cushionWidth = width * (float)0.10;
	}

	void Update() {
	}
	
	// Update is called once per frame
	private void OnGUI () {
		GUI.BeginGroup (new Rect (0, 0, width, height));
		GUI.DrawTexture (new Rect (width/2-cushionWidth*(float)1.5, cushionHeight/20, boom.width, boom.height), boom);
		GUI.skin = playSkin;
		GUI.Label (new Rect (width/2-cushionWidth, cushionHeight+20, 500, 200), "SQUABBLE");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (width/2+5-cushionWidth, cushionHeight+10, 500, 200), "SQUABBLE");
		GUI.skin = menuSkin;
		if (GUI.Button (new Rect(width/2, height/2+cushionHeight, 100, 50), "PLAY")) {
			playMode = true;
			Application.LoadLevel ("Whack-A-Mole_v1");
		}
		if (GUI.Button (new Rect(width/2, height/2+cushionHeight*(float)2, 100, 50), "TRAIN")) {
			playMode = false;
			Application.LoadLevel ("TrainMenu");
		}
		GUI.EndGroup ();
	}
}
