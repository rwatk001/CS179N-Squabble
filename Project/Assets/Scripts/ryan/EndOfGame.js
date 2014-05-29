//GameEnd Scene
// Used to run the end of game final score display 
var addSheep : boolean;
var continueChecking : boolean;
var count : int;
var endCount : int;
var timer : float;
var baseTime : float = 0.001;

function Start () {
	addSheep = true;
	continueChecking = true;
	count = 0;
	endCount = 100;//AddInScore.score;
	timer = baseTime;
//	GameObject.Find("chest").GetComponent(Animator).SetBool("close", false);
}

function Update () {
	spawn();
	if (continueChecking)
		checkCount();
}

function spawn () {
	if (addSheep) {
//		var sheepNum : int = Random.Range(1.0, 3.0);
//		for (var i : int = 0; i < sheepNum; i++) {
			var position: Vector3 = Vector3(Random.Range(-7.0, 7.0), 25, Random.Range(-4.0, 4.0));
			Instantiate(GameObject.Find("BadSheep").transform, position, Quaternion.identity);
//		}
		addSheep = false;
	}
}

function checkCount () {
	if (count >= endCount) {
		addSheep = false;
		yield WaitForSeconds(2);
		GameObject.Find("chest").GetComponent(Animator).SetBool("close", true);
		continueChecking = false;
	}
	else if (timer <= 0) {
		addSheep = true;
		timer = baseTime;
	} else {
		timer -= Time.deltaTime;
		
	}
}

function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "BadSheep") {
		count++;
	}
}