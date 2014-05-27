static var position1 : Vector3 = Vector3(15,0.7,0);
static var position2 : Vector3 = Vector3(15,2.2,0);

static var launched : boolean = false;

var rocket : GameObject;

function Start () {
}

function Update () {
	// -------- ANDREW ADDED -----------------------
	if (GameObject.Find ("Rocket(Clone)") == null) {
		launched = false;
	}
	else {
		launched = true;
	}
	// ---------------------------------------------
	if (!launched && !Timer.timesUpGO)
		spawnRocket();
}

function spawnRocket () {
	var pos : int = Random.Range(0, 2); //range 0-1
	var rocketClone : GameObject;
		if (pos == 1)
			rocketClone = Instantiate(rocket, position1, Quaternion.FromToRotation(this.transform.forward, Vector3.right));
		else 
			rocketClone = Instantiate(rocket, position2, Quaternion.FromToRotation(this.transform.forward, Vector3.right));
		
	launched = true;
}