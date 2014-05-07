
function Start () {
	GameObject.Find("Player").GetComponent(ParticleSystem).Stop();
}

function Update () {

}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Rocket") {
		HealthCount.life--;
		Destroy(inBound.gameObject);
		GameObject.Find("Player").GetComponent(ParticleSystem).Play();
		yield WaitForSeconds(0.5);
		Destroy(this.gameObject);
		CountSheepGO.lostLifeGO = true;
	}
}