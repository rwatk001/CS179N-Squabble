var speed : float;

function Start () {
	speed = Random.Range(10,18);
}

function Update () {
	this.transform.position.x -= speed * Time.deltaTime;
}