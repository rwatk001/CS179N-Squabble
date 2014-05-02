var gameTimer : float = 5.0;
var showTime : int;
var timeString : String = "Time: ";
static var gameOverSheep : boolean = false;
 
 function Start () {
 	gameTimer = 30;
 	gameOverSheep = false;
 }
 
function Update () {
	if(gameTimer > 0){
		gameTimer -= Time.deltaTime;
		showTime = gameTimer;
		timeString = "Time: " + showTime;
	}
	
	guiText.text = timeString;
	
	if(gameTimer <= 0){
//		Debug.Log("GAME OVER");
		gameOverSheep = true;
	}
}