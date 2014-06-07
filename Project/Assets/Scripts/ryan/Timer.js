var gameTimer : float = 5.0;
var showTime : int;
var timeString : String = "Time: ";
static var timesUpGO : boolean = false;
static var timeStart : boolean;
public var scoreGUI : GUIText;
static var score : int;
 
 function Start () {
 	score = 0;
 	gameTimer = 30;
 	showTime = gameTimer;
 	guiText.text = "TIME:   " + showTime.ToString();
 	scoreGUI.text = "SCORE:  " + score.ToString();
 	timesUpGO = false;
 	timeStart = false;
 }
 
function Update () {
	// ---- ANDREW ADDED -------------
	if (!timesUpGO && timeStart) {
		if (CountSheepGO.lostLifeGO) {
			timesUpGO = true;
		}
		gameTimer -= Time.deltaTime;
		showTime = gameTimer;
		if (showTime <= 5) {
			guiText.material.color = Color.red;
		}
		else {
			guiText.material.color = Color.white;
		}
		timeString = "Time:   " + showTime;
		guiText.text = timeString;
		scoreGUI.text = "SCORE:  " + score.ToString();
		if(gameTimer <= 0) {
			timesUpGO = true;
		}
	}
	else {
		gameTimer = 30;
	}
	// -------------------------------
}