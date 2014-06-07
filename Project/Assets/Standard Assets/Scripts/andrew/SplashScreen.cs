using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public static bool gameGO;

	// Awake ()
	void Awake () {
		gameGO = false;
	}

	// Update ()
	void Update () {
		if (Input.anyKey) {
			Destroy (this.gameObject);
			gameGO = true;
		}
	}
}
