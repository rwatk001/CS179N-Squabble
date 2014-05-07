var speed : float;

function Start () {
	speed = Random.Range(10,25);
}

function Update () {
	this.transform.position.x -= speed * Time.deltaTime;
}