//var scoreCount : int = 0;

function Start () {

}

function Update () {

}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Rocket" && !Timer.timesUpGO) {
		ScoreCountRocket.scoreCount++;
		AddInScore.score++;
		++DataContainer.finalScore;
		++Timer.score;
		Destroy(inBound.gameObject);
		RocketSpawn.launched = false;
	}
}