#pragma strict

static var scoreString : String = "x0";
var scoreCount : int = 0;

function Start () {
	for (var i : int = 0;i < 10; i++) {
		var position: Vector3 = Vector3(Random.Range(-7.0, 7.0), i+2, Random.Range(-4.0, 4.0));
		Instantiate(GameObject.Find("Barrel").transform, position, Quaternion.identity);
	}
}

function OnTriggerEnter (other : Collider) {
	if (GameObject.Find("Barrel").collider == other.collider) {
		scoreCount++;
		scoreString = "x" + scoreCount;
	}
}