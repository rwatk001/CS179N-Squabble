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
	if (inBound.gameObject.tag == "BadSheep") {
		scoreCount++;
		AddInScore.score++;
		scoreString = "x" + scoreCount;
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		Destroy(inBound.gameObject);
		audio.Play();
		SpawnBarrels.moreSheeps = true;
	}
	
	if (inBound.gameObject.tag == "GoodSheep") {
		HealthCount.life--;
//		Debug.Log(lifePoints);
		CountSheepGO.lostLifeGO = true;
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		GameObject.Find("GoodSheep").audio.Play();
		Destroy(inBound.gameObject);
	}
}