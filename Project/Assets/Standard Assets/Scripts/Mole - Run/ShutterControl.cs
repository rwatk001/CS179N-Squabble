using UnityEngine;
using System.Collections;

public class ShutterControl : MonoBehaviour {

	public static bool ReadyGO;
	public GameObject leftShutter;
	public GameObject rightShutter;
	public GUIText shutterCount;
	private float startTimer;

	// Start ()
	void Start () {
		ReadyGO = false;
		startTimer = 3;
		shutterCount.text = startTimer.ToString ();
	}
	
	// Update ()
	void Update () {
		
	}
}
