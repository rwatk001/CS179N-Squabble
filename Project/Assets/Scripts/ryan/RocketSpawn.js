static var position1 : Vector3 = Vector3(15,1,0);
static var position2 : Vector3 = Vector3(15,3,0);

static var launched : boolean = false;

var rocket : GameObject;

function Start () {
	launched = true;
}

function Update () {
	if (!launched)
		spawnRocket();
}

function spawnRocket () {
	var pos : int = Random.Range(0, 2); //range 0-1
//	Debug.Log(pos);
	var rocketClone : GameObject;
	if (pos == 1) {
		rocketClone = Instantiate(rocket, position1, Quaternion.FromToRotation(this.transform.forward, Vector3.left));
	} else { 
		rocketClone = Instantiate(rocket, position2, Quaternion.FromToRotation(this.transform.forward, Vector3.left));
	}
		
	launched = true;
}