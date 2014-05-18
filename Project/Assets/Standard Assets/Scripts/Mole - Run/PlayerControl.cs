using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject player;
	public GameObject timerObject;
	private TimerControl timerControl;
	private Animator animator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float speed;
	private bool eastHit;
	private bool westHit;
	private bool northHit;
	private bool southHit;

	void Awake() {
		speed = 10f;
		eastHit = false;
		westHit = false;
		northHit = false;
		southHit = false;
		timerControl = timerObject.GetComponent<TimerControl> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		if (eastHit) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			if (moveHorizontal < 0) {
				moveHorizontal = 0;
			}
			else {
				eastHit = false;
			}
			moveVertical = Input.GetAxis ("Vertical");
		}
		else if (westHit) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			if (moveHorizontal > 0) {
				moveHorizontal = 0;
			}
			else {
				westHit = false;
			}
			moveVertical = Input.GetAxis ("Vertical");
		}
		else if (northHit) {
			moveVertical = Input.GetAxis ("Vertical");
			if (moveVertical > 0) {
				moveVertical = 0;
			}
			else {
				northHit = false;
			}
			moveHorizontal = Input.GetAxis ("Horizontal");
		}
		else if (southHit) {
			moveVertical = Input.GetAxis ("Vertical");
			if (moveVertical < 0) {
				moveVertical = 0;
			}
			else {
				southHit = false;
			}
			moveHorizontal = Input.GetAxis ("Horizontal");
		}
		else {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}
		
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if (!timerControl.gameEnded) {
			player.transform.Translate (-movement * speed * Time.deltaTime);

			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (movement != Vector3.zero) {
				animator.SetBool("move", true);
			}
			else {
				animator.SetBool("move", false);
			}
			//if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Idle") || stateInfo.nameHash == Animator.StringToHash("Base Layer.Run")) {
			if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Idle 0") || stateInfo.nameHash == Animator.StringToHash("Base Layer.Attack 0")) {
				if (Input.GetMouseButtonDown(0)) {
					animator.SetBool ("hit", true);
				}
				else {
					animator.SetBool ("hit", false);
				}
			}
		}
	}

	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "East Wall") {
			eastHit = true;
		}
		else if (trigger.gameObject.tag == "West Wall") {
			westHit = true;
		}
		else if (trigger.gameObject.tag == "South Wall") {
			southHit = true;
		}
		else if (trigger.gameObject.tag == "North Wall") {
			northHit = true;
		}
	}
}
