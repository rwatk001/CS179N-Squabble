var gameTimer : float = 5.0;
var showTime : int;
var timeString : String = "Time: ";
static var timesUpGO : boolean = false;
static var timeStart : boolean;
 
 function Start () {
 	gameTimer = 30;
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
		timeString = "Time: " + showTime;
		if(gameTimer <= 0) {
			timesUpGO = true;
		}
	}
	else {
		gameTimer = 30;
	}
	// -------------------------------
	
	guiText.text = timeString;
}