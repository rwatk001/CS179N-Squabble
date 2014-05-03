using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour {

	public bool isPlayMode;
	private MenuControl menuControl;

	// Use this for initialization
	void Awake () {
		//DontDestroyOnLoad (transform.gameObject);
		DontDestroyOnLoad (this);
		menuControl = GameObject.Find ("Main Camera").GetComponent<MenuControl> ();
	}

	void Update() {
		isPlayMode = menuControl.playMode;
	}

}
