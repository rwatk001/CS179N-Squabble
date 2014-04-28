﻿static var moreSheeps : boolean = false;

function spawn () {
	if (moreSheeps) {
		var sheepNum : int = Random.Range(1.0, 3.0);
		for (var i : int = 0; i < sheepNum; i++) {
			var position: Vector3 = Vector3(Random.Range(-7.0, 7.0), 9+i, Random.Range(-4.0, 4.0));
			Instantiate(GameObject.Find("Barrel").transform, position, Quaternion.identity);
		}
		moreSheeps = false;
	}
}

function Start () {
	for (var i : int = 0; i < 10; i++) {
		var position: Vector3 = Vector3(Random.Range(-7.0, 7.0), i+2, Random.Range(-4.0, 4.0));
		Instantiate(GameObject.Find("Barrel").transform, position, Quaternion.identity);
	}
}

function Update () {
	spawn();
}