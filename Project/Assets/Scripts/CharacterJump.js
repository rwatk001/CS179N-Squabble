var speed : float = 3.0;
var gravity : float = 8.0;
var jumpSpeed : float = 8.0;
private var moveDirection : Vector3 = Vector3.zero;
 
function Update () {
	var controller : CharacterController = GetComponent(CharacterController);
	var forward : Vector3 = transform.TransformDirection(Vector3.left);
	var curSpeed : float = speed * Input.GetAxis ("Vertical");
	controller.SimpleMove(forward * curSpeed);
	 
	if (Input.GetButton("Jump")) {
		if(controller.isGrounded)
			moveDirection.y= jumpSpeed;
	} else {
		moveDirection.y -= gravity * Time.deltaTime;
	}

	controller.Move(moveDirection * Time.deltaTime);
}