static var tallyScore : boolean = false;

function Start () {
	tallyScore = false;
}

function checkGO() {
	if(Timer.gameOverSheep) {
		guiText.text = "Time's Up, Bro!";
		yield WaitForSeconds(3);
		tallyScore = true;
		//Application.LoadLevel("ScoreBoard");
	}
}

function Update () {
	checkGO();
}