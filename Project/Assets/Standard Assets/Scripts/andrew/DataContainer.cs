// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class DataContainer : MonoBehaviour {

	// public and private variables needed
	// to keep certain information through out the game
	public static DataContainer Instance;
	public static bool isPlayMode;
	public static bool gameOver;
	public static int level_1;
	public static int level_2;
	public static int level_3;
	public static int level_4;
	//public static int level_5;
	public static int life = 3;
	public static int finalScore;
	private MenuControl menuControl;

	// Awake ()
	// calls the DontDestoyOnLoad () to ensure this
	// script persists through all the levels
	// it holds the order of the levels on "Play Mode"
	// boolean to check if the mode is "Play Mode" or "Train Mode"
	// and the scores for each of the games depending on the game mode
	void Awake () {
		// instantiates only one DataContainer object in
		// its lifetime
		if (Instance) {
			DestroyImmediate(gameObject);
		}
		else {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
		finalScore = 0;
	}

	// Update ()
	void Update() {
		// determines whether the user enters "Play Mode" or "Train Mode"
		if (Application.loadedLevelName == "Menu") {
			resetHealth ();
			menuControl = GameObject.Find ("Main Camera").GetComponent<MenuControl> ();
			isPlayMode = menuControl.playMode;
		}
		if (Application.loadedLevelName != "Menu" && Application.loadedLevelName != "TrainMenuList"
		         && Application.loadedLevelName != "GameEnd") {
			displayHealth();
		}
		else {
			GameObject.Find("HealthBit3").guiTexture.enabled = false;
			GameObject.Find("HealthBit2").guiTexture.enabled = false;
			GameObject.Find("HealthBit1").guiTexture.enabled = false;
		}
	}

	public static void AssignLevel() {
		// randomly assigns the order the user will be playing the level
		// one the user has accomplished all the games but still has life
		// the game assigns a new order of levels and the player continues
		level_1 = Random.Range (3, 7);
		level_2 = Random.Range (3, 7);
		while (level_2 == level_1) {
			level_2 = Random.Range (3, 7);
		}
		level_3 = Random.Range (3, 7);
		while (level_3 == level_1 || level_3 == level_2) {
			level_3 = Random.Range (3, 7);
		}
		level_4 = Random.Range (3, 7);
		while (level_4 == level_1 || level_4 == level_2 || level_4 == level_3) {
			level_4 = Random.Range (3, 7);
		}
		/*level_5 = Random.Range (2, 6);
		while (level_5 == level_1 || level_5 == level_2 || level_5 == level_3 || level_5 == level_4) {
			level_5 = Random.Range (2, 6);
		}*/
	}

	public static void resetHealth () {
		life = 3;
		GameObject.Find("HealthBit3").guiTexture.enabled = true;
		GameObject.Find("HealthBit2").guiTexture.enabled = true;
		GameObject.Find("HealthBit1").guiTexture.enabled = true;
	}

	// displayHealth() is in charge of showcasing the life the user has
	// when life reaches zero the it set a game over boolean to true
	public void displayHealth() {
		if (isPlayMode) {
			if (life > 2) {
				GameObject.Find("HealthBit3").guiTexture.pixelInset = new Rect (-(Screen.width/2)+45,(Screen.height/2)-25, 20, 20);
			}
			else {
				//Destroy(GameObject.Find("HealthBit3"));
				//GameObject.Find("HealthBit3").SetActive (false);
				GameObject.Find("HealthBit3").guiTexture.enabled = false;
			}	
			if (life > 1) {
				GameObject.Find("HealthBit2").guiTexture.pixelInset = new Rect (-(Screen.width/2)+25,(Screen.height/2)-25, 20, 20);
			}
			else {
				//Destroy(GameObject.Find("HealthBit2"));
				//GameObject.Find("HealthBit2").SetActive (false);
				GameObject.Find("HealthBit2").guiTexture.enabled = false;
			}
			if (life > 0) {
				GameObject.Find("HealthBit1").guiTexture.pixelInset = new Rect (-(Screen.width/2)+5,(Screen.height/2)-25, 20, 20);
			}
			else {
				//Destroy(GameObject.Find("HealthBit1"));
				//GameObject.Find("HealthBit1").SetActive (false);
				GameObject.Find("HealthBit1").guiTexture.enabled = false;
			}
			if (life == 0) {
				gameOver = true;
				GameObject.Find("HealthBit3").guiTexture.pixelInset = new Rect (-10, 0, 0, 0);
				GameObject.Find("HealthBit2").guiTexture.pixelInset = new Rect (-10, 0, 0, 0);
				GameObject.Find("HealthBit1").guiTexture.pixelInset = new Rect (-10, 0, 0, 0);
			}
			else {
				gameOver = false;
			}
		}
		else {
			// life is not necessary in games played in "Train Mode"
			// simply place the image outside the game scene
			GameObject.Find("HealthBit3").guiTexture.pixelInset = new Rect (-10, 0, 0, 0);
			GameObject.Find("HealthBit2").guiTexture.pixelInset = new Rect (-10, 0, 0, 0);
			GameObject.Find("HealthBit1").guiTexture.pixelInset = new Rect (-10, 0, 0, 0);
		}
	}
}
