#pragma strict

static var activeMove : boolean = true;
var isStopping : boolean = true;
static var waitTextString : String = "";
var stopVec : Vector3 = Vector3.down;
var loc : int = 0;

function Start () {
	activeMove = true;
	loc = 0;

}

function Update () {
	if (LineMouse.myPoints.Length > 0 /*!= null*/ && activeMove) {
		for(var point : Vector3 in LineMouse.myPoints) {
		//var point : Vector3 = LineMouse.myPoints[loc];
			isStopping = false;
			GameObject.Find("Player").GetComponent(Animator).SetBool("running", true);
			MoveObject(GameObject.Find("Player").transform, GameObject.Find("Player").transform.position, point, 7.0);
		}
		isStopping = true;
	} else {
		GameObject.Find("Player").GetComponent(Animator).SetBool("running", false);
		//GameObject.Find("Player").GetComponent(CharacterController).SimpleMove(stopVec);
	}
//	if (isStopping) {
//		GameObject.Find("Player").GetComponent(CharacterController).SimpleMove(stopVec);
//	}
}

function MoveObject (thisTransform : Transform, startPos : Vector3, endPos : Vector3, time : float) {
    //var i = 0.0;
    //var rate = 1.0/time;
	//i += Time.deltaTime * rate;
	thisTransform.LookAt(endPos);
	var moveVector : Vector3 = endPos - startPos;
	if (moveVector.magnitude > 0.0001f) {
		moveVector = moveVector.normalized * time;
	    GameObject.Find("Player").GetComponent(CharacterController).SimpleMove(moveVector);// * 0.015/*Time.deltaTime*/);
//	} else {
//		if (LineMouse.myPoints.Length < loc)
			//loc++;
	}
}
