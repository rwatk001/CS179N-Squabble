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
var helpCount : int;
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
			GUI.BeginGroup (new Rect(0, 0, width, height));
			GUI.Box (new Rect(cushionWidth*3, cushionHeight, width*0.40f, height*0.80f), "");
			GUI.BeginGroup (new Rect (cushionWidth*3, cushionHeight, width, height));
			GUI.skin = scoreSkin;
			GUI.Label (new Rect (cushionWidth*1.3f, cushionHeight/2, width, height), "SCORE");
			// determines which score is going to be displayed
			// it will either be the final score when you run out of lives or
			// an individual score based on the game you just played
			if (DataContainer.isPlayMode) {
				score = DataContainer.finalScore;
			}
			else {
				score = Timer.score;
			}
			// "Train Mode" allows you to go back and choose other levels to practice
			// before taking on "Play Mode"
			GUI.Label (new Rect (cushionWidth*1.8f, cushionHeight*3, width, height), score.ToString());
			if (!DataContainer.isPlayMode) {
				GUI.skin = menuSkin;
				if (GUI.Button (new Rect (cushionWidth*2.5f, cushionHeight*6.50f, 100, 50), "BACK")) {
					//reloadReset ();
					Application.LoadLevel ("TrainMenuList");
				}
				GUI.skin = replaySkin;
				// "Train Mode" also gives you the option to replay the level at the end
				// for any reason
				if (GUI.Button (new Rect (cushionWidth*0.75f, cushionHeight*6.50f, 100, 50), "REPLAY")) {
					//reloadReset ();	
					Application.LoadLevel (Application.loadedLevel);
				}
			}
			// displays the final score and reverts you back to the main title screen
			else if (DataContainer.gameOver) {
				GUI.skin = playSkin;
				if (GUI.Button (new Rect (cushionWidth*1.8f, cushionHeight*6.50f, 100, 50), "FINISH")) {
					//reloadReset ();
					Application.LoadLevel ("GameEnd");
				}
			}
			// part of "Play Mode" that you can only move forward
			// displays the right score and the next level is predetermined by the DataContainer script
			else {
				GUI.skin = playSkin;
				if (GUI.Button (new Rect (cushionWidth*1.8f, cushionHeight*6.50f, 100, 50), "CONTINUE")) {
					//reloadReset ();
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
						//Application.LoadLevel (DataContainer.level_5);
					}
					/*else if (Application.loadedLevel == DataContainer.level_5) {
						DataContainer.AssignLevel ();
						Application.LoadLevel (DataContainer.level_1);
					}*/
				}
			}
		GUI.EndGroup ();
		GUI.EndGroup ();
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
	score = 0;
}
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

function Update () {
//	updateScore();
}