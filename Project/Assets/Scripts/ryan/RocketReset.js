//var scoreCount : int = 0;

function Start () {

}

function Update () {

}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Rocket") {
		ScoreCountRocket.scoreCount++;
		AddInScore.score++;
		Destroy(inBound.gameObject);
		RocketSpawn.launched = false;
	}
}