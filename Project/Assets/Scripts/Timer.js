var gameTimer : float = 5.0;
var showTime : int;
var timeString : String = "Time: ";
static var timesUpGO : boolean = false;
 
 function Start () {
 	gameTimer = 30;
 	timesUpGO = false;
 }
 
function Update () {
	if(gameTimer > 0 && !CountSheepGO.lostLifeGO){
		gameTimer -= Time.deltaTime;
		showTime = gameTimer;
		timeString = "Time: " + showTime;
	}
	
	guiText.text = timeString;
	
	if(gameTimer <= 0){
		timesUpGO = true;
	}
}