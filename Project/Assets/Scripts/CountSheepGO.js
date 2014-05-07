//static var tallyScore : boolean = false;
static var lostLifeGO : boolean = false;

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
//		ScoreCountRocket.scoreCount += AddInScore.score;
	}
	else if (lostLifeGO) {
		guiText.text = "You Fail Bro...";
		yield WaitForSeconds(3);
		AddInScore.tallyScore = true;
		FollowLine.activeMove = false;
//		ScoreCountRocket.scoreCount += AddInScore.score;
	}
}

function Update () {
	checkGO();
}