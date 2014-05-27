var gameTimer : float = 5.0;
var showTime : int;
var timeString : String = "Time: ";
static var timesUpGO : boolean = false;
 
 function Start () {
 	gameTimer = 30;
 	timesUpGO = false;
 }
 
function Update () {
	// ---- ANDREW ADDED -------------
	if (!timesUpGO) {
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