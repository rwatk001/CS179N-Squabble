using UnityEngine;
using System.Collections;

public class MasterMoleControl : MonoBehaviour {

	public int totalHits;
	private MoleControl moleControl;
	public GameObject timerObject;
	private TimerControl timerControl;
	private bool scoreUpdate;

	// Use this for initialization
	void Start () {
		timerControl = timerObject.GetComponent<TimerControl> ();
		scoreUpdate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerControl.gameEnded && totalHits == 0) {
			scoreUpdate = true;
		}
		else {
			scoreUpdate = false;
		}
		if (scoreUpdate) {
			foreach (Transform child in transform) {
				moleControl = child.gameObject.GetComponent<MoleControl>();
				totalHits += moleControl.numHits;
			}
			scoreUpdate = false;
		}
	}
}
