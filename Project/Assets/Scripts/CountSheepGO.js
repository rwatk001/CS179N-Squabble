static var lostLifeGO : boolean = false;

var timerUp : boolean;

function Start () {
	lostLifeGO = false;
	tallyScore = false;
}


function checkGO() {
	if(Timer.timesUpGO) {
		guiText.text = "Good Job Dude!";
		yield WaitForSeconds(3);
		AddInScore.tallyScore = true;
		FollowLine.activeMove = false;
	}
	else if (lostLifeGO) {
		guiText.text = "You Fail Bro...";
		yield WaitForSeconds(3);
		AddInScore.tallyScore = true;
		FollowLine.activeMove = false;
	}
}

function Update () {
	checkGO();
} 	