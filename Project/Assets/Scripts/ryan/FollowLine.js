#pragma strict

static var activeMove : boolean = true;
var isStopping : boolean = true;
static var waitTextString : String = "";
var stopVec : Vector3 = Vector3.down;

function Start () {
	activeMove = true;

}

function Update () {
	if (LineMouse.myPoints != null && activeMove) {
		for(var point : Vector3 in LineMouse.myPoints) {
			isStopping = false;
			GameObject.Find("Player").GetComponent(Animator).SetBool("running", true);
			MoveObject(GameObject.Find("Player").transform, GameObject.Find("Player").transform.position, point, 5.0);
		}
		isStopping = true;
	} else {
		GameObject.Find("Player").GetComponent(Animator).SetBool("running", false);
	}
	if (isStopping) {
		GameObject.Find("Player").GetComponent(CharacterController).SimpleMove(stopVec);
	}
}

function MoveObject (thisTransform : Transform, startPos : Vector3, endPos : Vector3, time : float) {
    var i = 0.0;
    var rate = 1.0/time;
	i += Time.deltaTime * rate;
	thisTransform.LookAt(endPos);
	var moveVector : Vector3 = endPos - startPos;
	if(moveVector.magnitude > 0.1f) {
		moveVector = moveVector.normalized * time;
	    GameObject.Find("Player").GetComponent(CharacterController).Move(moveVector * Time.deltaTime);
	}
}
