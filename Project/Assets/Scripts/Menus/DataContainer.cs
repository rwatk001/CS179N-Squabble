using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour {

	public static bool isPlayMode;
	public static int levelCount = 0;
	public static DataContainer Instance;
	private MenuControl menuControl;

	// Use this for initialization
	void Awake () {
		if (Instance) {
			DestroyImmediate(gameObject);
		}
		else {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
	}

	void Update() {
		if (Application.loadedLevelName == "Menu") {
			menuControl = GameObject.Find ("Main Camera").GetComponent<MenuControl> ();
			isPlayMode = menuControl.playMode;
		}
	}
}
