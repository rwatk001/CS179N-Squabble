static var scoreString : String = "x0";
var scoreCount : int = 0;

function Start () {
	scoreCount = 0;
	scoreString = "x" + scoreCount;
}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Sheep") {
		scoreCount++;
		AddInScore.globalScore++;
		scoreString = "x" + scoreCount;
		GameObject.Find("Pen").GetComponent(ParticleSystem).Play();
		Destroy(inBound.gameObject);
		SpawnBarrels.moreSheeps = true;
	}
}