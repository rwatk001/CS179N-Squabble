static var score : int;
static var life : int = 3;
static var tallyScore : boolean;
var boardScore : int = 0;
var readyButton : boolean = false;
static var goLevel : boolean = false;

var buttonWidth : int = 200;
var buttonHeight : int = 100;

//From WAM ScoreContol @@@@@@@@@@@@
var playSkin : GUISkin;
var replaySkin : GUISkin;
var scoreSkin : GUISkin;
var menuSkin : GUISkin;
var showScore : boolean;
var height : float;
var width : float;
var cushionHeight : float;
var cushionWidth : float;
var scoreCount : int;
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


function updateScore () {
	if (tallyScore) {
		while (boardScore < score) {
			boardScore++;
			guiText.text = boardScore.ToString();
			yield WaitForSeconds(10);
		}
		guiText.text = boardScore.ToString();
		if (GameObject.Find("ScoreBoardText").transform.position.y < 0.75) {
			GameObject.Find("ScoreBoardText").transform.Translate(Vector3.up * Time.deltaTime/2);
		} else 
			readyButton = true;
	}
}

function setReadyBut () {
	if (readyButton) {
		if (GUI.Button(Rect(Screen.width/2 - buttonWidth/2, Screen.height/2,
			buttonWidth, buttonHeight),"Ready?")) {
			goLevel = true;
			yield WaitForSeconds(1);
			Application.LoadLevel("BarrelBreaker");
		}
	}
}

function OnGUI() {
//	setReadyBut();
	if (tallyScore) {
		//From WAM ScoreContol @@@@@@@@@@@@
		GUI.BeginGroup (new Rect(0, 0, width, height));
		GUI.Box (new Rect(cushionWidth*3, cushionHeight, width*0.40f, height*0.80f), "");
		GUI.BeginGroup (new Rect (cushionWidth*3, cushionHeight, width, height));
		GUI.skin = scoreSkin;
		GUI.Label (new Rect (cushionWidth*1.3f, cushionHeight/2, width, height), "SCORE");
		scoreCount = score;
		GUI.Label (new Rect (cushionWidth*1.4f, cushionHeight*3, width, height), scoreCount.ToString());
		if (!DataContainer.isPlayMode) {
			GUI.skin = menuSkin;
			if (GUI.Button (new Rect (cushionWidth*2.5f, cushionHeight*6.5f, 100, 50), "BACK")) {
				if (Application.loadedLevelName == "BarrelBreaker") {
					Application.LoadLevel ("TrainMenu");
				}
				else if (Application.loadedLevelName == "RocketJump") {
					Application.LoadLevel ("TrainMenu2");
				}	
			}
			GUI.skin = replaySkin;
			if (GUI.Button (new Rect (cushionWidth*0.75f, cushionHeight*6.50f, 100, 50), "REPLAY")) {
				Application.LoadLevel ("BarrelBreaker");
				//Application.LoadLevel(Application.loadedLevel);
				FollowLine.activeMove = false;
			}
		}
		else if (DataContainer.gameOver) {
			GUI.skin = playSkin;
			if (GUI.Button (new Rect (cushionWidth*1.8f, cushionHeight*6.5f, 100, 50), "FINISH")) {
				Application.LoadLevel ("Menu");
			}
		}
		else {
			GUI.skin = playSkin;
			if (GUI.Button (new Rect (cushionWidth*1.8f, cushionHeight*6.50f, 100, 50), "CONTINUE")) {
				if (Application.loadedLevel == DataContainer.level_1) {
					Application.LoadLevel (DataContainer.level_2);
				}
				else if (Application.loadedLevel == DataContainer.level_2) {
					Application.LoadLevel (DataContainer.level_3);
				}
				else if (Application.loadedLevel == DataContainer.level_3) {
					Application.LoadLevel (DataContainer.level_4);
				}
				else if (Application.loadedLevel == DataContainer.level_4) {
					DataContainer.AssignLevel ();
					Application.LoadLevel (DataContainer.level_1);
				}
			}
		}
		GUI.EndGroup ();
		GUI.EndGroup ();
		// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	}
}

//From WAM ScoreContol @@@@@@@@@@@@
function Start () {
	tallyScore = false;
	showScore = false;
	height = Screen.height;
	width = Screen.width;
	cushionHeight = height * 0.10f;
	cushionWidth = width * 0.10f;
	helpCount = 0;
}
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

function Update () {
//	updateScore();
}