
function Start () {
	GameObject.Find("Player").GetComponent(ParticleSystem).Stop();
}

function Update () {

}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "Rocket") {
		if (DataContainer.isPlayMode) {
			HealthCount.life--;
			--DataContainer.life;
		}
		else {
			--Timer.score;
			RocketSpawn.launched = false;
		}
		Destroy(inBound.gameObject);
		GameObject.Find("Player").GetComponent(ParticleSystem).Play();
		GameObject.Find("rocketScene").audio.Play();
		yield WaitForSeconds(0.5);
		GameObject.Find("Player").GetComponent(ParticleSystem).Stop();
		GameObject.Find("rocketScene").audio.Stop();
		if (DataContainer.isPlayMode) {
			CountSheepGO.lostLifeGO = true;
			Destroy(this.gameObject);
		}
	}
}