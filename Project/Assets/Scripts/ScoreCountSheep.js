static var scoreString : String = "x0";
var scoreCount : int = 0;

function Start () {
	scoreCount = 0;
	scoreString = "x" + scoreCount;
	lostLifeGO = false;
}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "BadSheep") {
		scoreCount++;
		AddInScore.score++;
		scoreString = "x" + scoreCount;
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		Destroy(inBound.gameObject);
		SpawnBarrels.moreSheeps = true;
	}
	
	if (inBound.gameObject.tag == "GoodSheep") {
		// ------ ANDREW ADDED -------------
		--DataContainer.life;
		if (DataContainer.isPlayMode) {
			CountSheepGO.lostLifeGO = true;
		}
		else {
			--AddInScore.score;
			--scoreCount;
			scoreString = "x" + scoreCount;
		}
		// ----------------------------------
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		Destroy(inBound.gameObject);
	}
}