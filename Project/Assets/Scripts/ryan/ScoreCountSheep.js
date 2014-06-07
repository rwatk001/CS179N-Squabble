static var scoreString : String = "x0";
var scoreCount : int = 0;
//static var lifePoints : int = 3;
//static var lostLifeGO : boolean;

function Start () {
	scoreCount = 0;
	scoreString = "x" + scoreCount;
	lostLifeGO = false;
}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "BadSheep" && !Timer.timesUpGO) {
		scoreCount++;
		AddInScore.score++;
		++DataContainer.finalScore;
		++Timer.score;
		scoreString = "x" + scoreCount;
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		Destroy(inBound.gameObject);
		audio.Play();
		SpawnBarrels.moreSheeps = true;
	}
	
	if (inBound.gameObject.tag == "GoodSheep") {
		if (DataContainer.isPlayMode) {
			HealthCount.life--;
			--DataContainer.life;
			CountSheepGO.lostLifeGO = true;
		}
		else {
			Timer.score = 0;
		}
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		GameObject.Find("GoodSheep").audio.Play();
		Destroy(inBound.gameObject);
	}
}