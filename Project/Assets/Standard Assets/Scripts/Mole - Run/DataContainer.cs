using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour {

	public static bool isPlayMode;
	public static bool gameOver;
	public static DataContainer Instance;
	public static int level_1;
	public static int level_2;
	public static int level_3;
	public static int level_4 = 0;
	public static int life = 3;
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
		else if (Application.loadedLevelName != "Menu" || Application.loadedLevelName != "TrainMenu") {
			displayHealth();
		}
	}

	public static void AssignLevel() {
		level_1 = Random.Range (3, 6);
		level_2 = Random.Range (3, 6);
		while (level_2 == level_1) {
			level_2 = Random.Range (3, 6);
		}
		level_3 = Random.Range (3, 6);
		while (level_3 == level_1 || level_3 == level_2) {
			level_3 = Random.Range (3, 6);
		}
		level_4 = Random.Range (3, 6);
		while (level_4 == level_1 || level_4 == level_2 || level_4 == level_3) {
			level_4 = Random.Range (3, 6);
		}
	}

	public void displayHealth() {
		if (isPlayMode) {
			if (life > 2) {
				GameObject.Find("HealthBit3").guiTexture.pixelInset = new Rect (-(Screen.width/2)+45,(Screen.height/2)-25, 20, 20);
			}
			else {
				Destroy(GameObject.Find("HealthBit3"));
			}	
			if (life > 1) {
				GameObject.Find("HealthBit2").guiTexture.pixelInset = new Rect (-(Screen.width/2)+25,(Screen.height/2)-25, 20, 20);
			}
			else {
				Destroy(GameObject.Find("HealthBit2"));
			}
			if (life > 0) {
				GameObject.Find("HealthBit1").guiTexture.pixelInset = new Rect (-(Screen.width/2)+5,(Screen.height/2)-25, 20, 20);
			}
			else {
				Destroy(GameObject.Find("HealthBit1"));
			}
			if (life == 0) {
				gameOver = true;
			}
			else {
				gameOver = false;
			}
		}
		else {
			GameObject.Find("HealthBit3").guiTexture.pixelInset = new Rect (0, 0, 0, 0);
			GameObject.Find("HealthBit2").guiTexture.pixelInset = new Rect (0, 0, 0, 0);
			GameObject.Find("HealthBit1").guiTexture.pixelInset = new Rect (0, 0, 0, 0);
		}
	}
}
