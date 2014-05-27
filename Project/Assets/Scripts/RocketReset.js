function Start () {

}

function Update () {

}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Rocket") {
		ScoreCountRocket.scoreCount++;
		AddInScore.score++;
		Destroy(inBound.gameObject);
		//Destroy(GameObject.Find ("Rocket(Clone)"));
		RocketSpawn.launched = false;
	}
}