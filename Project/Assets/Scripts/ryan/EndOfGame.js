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
}

function Update () {
	spawn();
	if (continueChecking)
		checkCount();
}

// Function to spawn the sheep that will fall into the chest
function spawn () {
	// If the addSheep var is true then we add a sheep and wait for next update period
	if (addSheep) {
		var position: Vector3 = Vector3(Random.Range(-7.0, 7.0), 25, Random.Range(-4.0, 4.0));
		Instantiate(GameObject.Find("BadSheep").transform, position, Quaternion.identity);
		// Create a stop to wait for next period
		addSheep = false;
	}
}

// Function to control the when to drop a sheep
function checkCount () {
	// All the sheep have fallen so close the chest
	if (count >= endCount) {
		addSheep = false;
		yield WaitForSeconds(2);
		GameObject.Find("chest").GetComponent(Animator).SetBool("close", true);
		continueChecking = false;
	}
	// period is up so add a sheep and reset timer
	else if (timer <= 0) {
		addSheep = true;
		timer = baseTime;
	} else { // timer to create some spacing between the falling sheep
		timer -= Time.deltaTime;
		
	}
}

// Function used in conjuction with a trigger collider on the chest to 
//  determine how many sheep have fallen
function OnTriggerEnter (inBound : Collider) {
	if (inBound.gameObject.tag == "BadSheep") {
		count++;
	}
}