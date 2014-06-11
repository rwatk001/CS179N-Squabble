// The opening splash screen

var timer : float;

function Start () {
	timer = 3.0;
}

function Update () {
	countDown();
	if(Input.anyKey) {
		Application.LoadLevel ("Menu");
	}
}

function countDown () {
	timer -= Time.deltaTime;
	if(timer <= 0) {
		Application.LoadLevel ("Menu");
	}
}