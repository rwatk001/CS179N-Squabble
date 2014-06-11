#pragma strict

function Start () {
	buildRandLoc ();
}

function buildRandLoc () {
	var position : Vector3 = Vector3(Random.Range(-7.0, 7.0), 0.3, Random.Range(-4.0, 4.0));
	var rotation = Quaternion.Euler (0, Random.Range(0.0, 90.0), 0);
	var gate : GameObject = GameObject.Find("sheepGate");
	gate.transform.position = position;
	gate.transform.rotation = rotation;
}