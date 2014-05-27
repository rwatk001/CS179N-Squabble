using UnityEngine;
using System.Collections;

public class GameOverYield : MonoBehaviour {

	public GameObject timerObject;
	public static bool showScoreNow;
	private TimerControl timerControl;

	// Use this for initialization
	void Start () {
		//timerControl = timerObject.GetComponent<TimerControl> ();
		showScoreNow = false;
	}

	private IEnumerator Wait () {
		yield return new WaitForSeconds(3);
	}

	// Update is called once per frame
	void Update () {
		//if(timerControl.gameEnded) {
		if (TimerControl.gameEnded) {
			guiText.text = "Good Job Dude!";
			StartCoroutine(Wait ());
			showScoreNow = true; 
		}
		else if (MoleControl.lostLifeGO) {
			guiText.text = "You Fail Bro...";
			StartCoroutine(Wait ());
			showScoreNow = true;
		}
		else {
			showScoreNow = false;
		}
	}
}
