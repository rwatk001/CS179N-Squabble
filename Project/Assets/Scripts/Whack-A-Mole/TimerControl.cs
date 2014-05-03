using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TimerControl : MonoBehaviour {

	public bool gameEnded;
	public GUIText timerText;
	private float count;
	private int timerCount;
	private string text;
	//private float height;
	//private float width;

	// Use this for initialization
	void Start () {
		count = 20;
		timerCount = (int)count;
		timerText.text = count.ToString ();
		gameEnded = false;
		//width = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameEnded) {
			count -= Time.deltaTime;
			timerCount = (int)count;
			timerText.text = timerCount.ToString();
			if (count >= 0) {
				gameEnded = false;
			}
			else {
				gameEnded = true;
			}
		}
	}

	/*private void OnGui() {
		if (!gameEnded) {
			GUI.Button (new Rect(0, 0, 100, 100), "Test");
			GUI.Label (new Rect (width/2, 0, 75, 25), text);
		}
	}*/
}
