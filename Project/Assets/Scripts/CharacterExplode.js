
function Start () {
	GameObject.Find("Player").GetComponent(ParticleSystem).Stop();
}

function Update () {

}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Rocket") {
		Destroy(inBound.gameObject);
		//Destroy(GameObject.Find ("Rocket(Clone)"));
		GameObject.Find("Player").GetComponent(ParticleSystem).Play();
		yield WaitForSeconds(0.5);
		// ------- ANDREW ADDED --------------
		if (DataContainer.isPlayMode) {
			--DataContainer.life;
			CountSheepGO.lostLifeGO = true;
			Destroy(this.gameObject);
			//RocketSpawn.launched = false;
		}
		else {
			--AddInScore.score;
			--ScoreCountRocket.scoreCount;
			RocketSpawn.launched = false;
		}
		// -----------------------------------
	}
}