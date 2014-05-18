using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TrainMenuControl : MonoBehaviour {
	
	public GUISkin menuSkin;
	public GUISkin playSkin;
	public GUISkin replaySkin;
	public GUISkin lazySkin;
	public GUISkin arrowSkin;
	public Texture2D boom;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;
	private Ray ray;
	
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
		GUI.skin = menuSkin;
		if (GUI.Button (new Rect(cushionWidth-100, cushionHeight, 100, 50), "BACK")) {
			Application.LoadLevel("Menu");
		}
		GUI.skin = arrowSkin;
		if (GUI.Button (new Rect(width-cushionWidth, cushionHeight, 75, 75), "")) {
			Application.LoadLevel("TrainMenu2");
		}
		GUI.BeginGroup (new Rect (cushionWidth+50, cushionHeight/20, width, height));
		GUI.DrawTexture (new Rect (0, 0, boom.width, boom.height), boom);
		GUI.skin = lazySkin;
		if (GUI.Button (new Rect (0, 0, boom.width, boom.height), "")) {
			Application.LoadLevel("Whack-A-Mole");
		}
		GUI.skin = playSkin;
		GUI.Label (new Rect (0, cushionHeight+20, 700, 200), "WHACK-A-MOLE");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (5, cushionHeight+10, 700, 200), "WHACK-A-MOLE");
		GUI.EndGroup ();
		GUI.BeginGroup (new Rect (width/2+cushionWidth*(float)0.6, cushionHeight*2, width, height));
		GUI.DrawTexture (new Rect (0, 0, boom.width, boom.height), boom);
		GUI.skin = lazySkin;
		if (GUI.Button (new Rect (0, 0, boom.width, boom.height), "")) {
			Application.LoadLevel("BarrelBreaker");
		}
		GUI.skin = playSkin;
		GUI.Label (new Rect (0, cushionHeight+20, 700, 200), "COUNTING SHEEP");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (5, cushionHeight+10, 700, 200), "COUNTING SHEEP");
		GUI.EndGroup ();
		GUI.BeginGroup (new Rect (width/2-cushionWidth*(float)3.5+50, cushionHeight*(float)5.5, width, height));
		GUI.DrawTexture (new Rect (0, 0, boom.width, boom.height), boom);
		GUI.skin = lazySkin;
		if (GUI.Button (new Rect (0, 0, boom.width, boom.height), "")) {
			//Application.LoadLevel("");
		}
		GUI.skin = playSkin;
		GUI.Label (new Rect (0, cushionHeight+20, 700, 200), "CROSSING STREET");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (5, cushionHeight+10, 700, 200), "CROSSING STREET");
		GUI.EndGroup ();
	}
}