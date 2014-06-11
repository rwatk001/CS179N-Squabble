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
		GUI.DrawTexture (new Rect (width/2 - boom.width/2, height/2 - boom.height/2, boom.width, boom.height), boom);
		GUI.skin = playSkin;
		GUI.Label (new Rect (width/2-cushionWidth, cushionHeight+20, 500, 200), "MINIGAMES");
		GUI.skin = replaySkin;
		GUI.Label (new Rect (width/2+5-cushionWidth, cushionHeight+10, 500, 200), "MINIGAMES");
		GUI.EndGroup ();
		GUI.skin = playSkin;
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f, 300, 35), "NIGHT OF THE LIVING MUTTON")) {
			Application.LoadLevel ("Whack-A-Mole");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f+40, 300, 35), "COUNTING SHEEP")) {
			Application.LoadLevel ("BarrelBreaker");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f+80, 300, 35), "UNICORN RUNDOWN")) {
			Application.LoadLevel ("Frogger");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f+120, 300, 35), "COUNT DRACU-BAAH")) {
			Application.LoadLevel ("TargetPractice");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f+160, 300, 35), "ROASTED LAMB")) {
			Application.LoadLevel ("RocketJump");
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f+200, 300, 35), "TEMPLE OF THE ANCIENT ARIES")) {
			Application.LoadLevel ("Run Run"); 
		}
		if (GUI.Button (new Rect(width/2-cushionWidth/1.5f, height/2.5f+240, 300, 35), "BACK")) {
			Application.LoadLevel ("Menu");
		}
	}
}
