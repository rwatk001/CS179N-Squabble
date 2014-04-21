#pragma strict

var activeMove : boolean = true;
static var waitTextString : String = "";

function Start () {

}

function Update () {
	if (LineMouse.myPoints != null && activeMove) {
		for(var point : Vector3 in LineMouse.myPoints) {
			MoveObject(GameObject.Find("Player").transform, GameObject.Find("Player").transform.position, point, 5.0);
		}
	}
}

function MoveObject (thisTransform : Transform, startPos : Vector3, endPos : Vector3, time : float) {
    var i = 0.0;
    var rate = 1.0/time;
//    while (i < 1.0) {
        i += Time.deltaTime * rate;
        thisTransform.LookAt(endPos);
//        thisTransform.position = Vector3.Lerp(startPos, endPos, i);
		//Chaaracter Controller Beginnings
		var moveVector : Vector3 = endPos - startPos;
		if(moveVector.magnitude > 0.1f) {
			moveVector = moveVector.normalized * time;
	    	GameObject.Find("Player").GetComponent(CharacterController).Move(moveVector * Time.deltaTime);
//        yield; 
        }
//    }
}

function OnTriggerEnter (other : Collider) {
//	var playerPos : Vector3 = GameObject.Find("Player").transform.position;
	var boundPos : Vector3 = new Vector3(0,1,0);
	activeMove = false;
	waitTextString = "WAIT FOR IT!\n3";
	yield WaitForSeconds(1);
	waitTextString = "WAIT FOR IT!\n2";
	yield WaitForSeconds(1);
	waitTextString = "WAIT FOR IT!\n1";
	yield WaitForSeconds(1);
	waitTextString = "";
	MoveObject(GameObject.Find("Player").transform, GameObject.Find("Player").transform.position, boundPos, 0.5);
	activeMove = true;
}
