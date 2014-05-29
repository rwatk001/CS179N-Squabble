#pragma strict

function Start () {
	enabled = true;
}

function Update () {
	if(Input.anyKey) {
		Destroy(this.gameObject);
		Timer.timeStart = true;
	}
}