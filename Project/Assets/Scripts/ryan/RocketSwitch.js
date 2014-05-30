var moveUp : boolean;
var moveDn : boolean;

var speed : float;
var switcher : int;

function Start () {
	moveUp = false;
	moveDn = false;
	speed = 20.0;
	switcher = Random.Range(0,2);
}

function Update () {
	if (moveUp) {
		if (this.transform.position.y < RocketSpawn.position2.y)
			this.transform.position.y += speed * Time.deltaTime;
		else
			moveUp = false;
	}
	else if (moveDn) {
		if (this.transform.position.y > RocketSpawn.position1.y)
			this.transform.position.y -= speed * Time.deltaTime;
		else
			moveDn = false;
	}
}

function OnTriggerEnter (inBound : Collider) {
	switcher = Random.Range(0,2);
	Debug.Log(switcher);
	if (switcher == 1) {
		if (inBound.gameObject.tag == "Switch") {
			if (this.transform.position.y < RocketSpawn.position2.y)
				moveUp = true;
			//else if (this.transform.position.y == RocketSpawn.position2.y)
			else //if (RocketSpawn.p2)
				moveDn = true;
		}
	}
}