// Rocket Jump Scene
// Used to drive the jump event of the character

var speed : float = 1.0;
var gravity : float = 1.0;
var jumpSpeed : float = 1.0;
private var moveDirection : Vector3 = Vector3.zero;
 
function Update () {
	var controller : CharacterController = GetComponent(CharacterController);
	var forward : Vector3 = transform.TransformDirection(Vector3.left);
	var curSpeed : float = speed * Input.GetAxis ("Vertical");
	controller.SimpleMove(forward * curSpeed);
	if(controller.isGrounded)
	 GameObject.Find("Player").GetComponent(Animator).SetBool("jumping", false);
	// Originally used Input.GetButtonDown("Jump") which was bound to [space]
	//  but anyKey will allow either [space] or mouse click
	if (Input.anyKeyDown) {
		if(controller.isGrounded) {
			moveDirection.y = jumpSpeed;
			GameObject.Find("Player").GetComponent(Animator).SetBool("jumping", true);
		}
	} else {
		moveDirection.y -= gravity * Time.deltaTime + 0.3;
	}

	controller.Move(moveDirection * Time.deltaTime);
}