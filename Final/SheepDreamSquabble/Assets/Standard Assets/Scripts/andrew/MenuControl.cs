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
	//private float cushionWidth;

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * (float)0.10;
		//cushionWidth = width * (float)0.10;
	}

	void Update() {
	}
	
	// Update is called once per frame
	private void OnGUI () {
		GUI.BeginGroup (new Rect (0, 0, width, height));
		GUI.DrawTexture (new Rect (width/2 - boom.width/2, height/2 - boom.height/2, boom.width, boom.height), boom);
		GUI.skin = playSkin;
		GUI.Label (new Rect (width/2-400, cushionHeight+20, 800, 200), "Sheep Dream SQUABBLE");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (width/2+5-400, cushionHeight+10, 800, 200), "Sheep Dream SQUABBLE");
		GUI.skin = menuSkin;
		if (GUI.Button (new Rect(width/2 - 150, height/2+cushionHeight, 300, 50), "NIGHTMARE MODE")) {
			DataContainer.AssignLevel ();
			playMode = true;
			Application.LoadLevel (DataContainer.level_1);
			//Application.LoadLevel ("RocketJump");
		}
		if (GUI.Button (new Rect(width/2 - 100, height/2+cushionHeight*(float)2.5f, 200, 50), "FREE PLAY")) {
			playMode = false;
			Application.LoadLevel ("TrainMenuList");
		}
		GUI.EndGroup ();
	}
}
