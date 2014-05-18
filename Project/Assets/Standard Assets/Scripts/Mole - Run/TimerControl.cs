using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TimerControl : MonoBehaviour {

	public bool gameEnded;
	public GUIText timerText;
	private float count;
	private int timerCount;
	private string text;

	// Use this for initialization
	void Start () {
		count = 30;
		timerCount = (int)count;
		timerText.text = count.ToString ();
		gameEnded = false;
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
	}
}
