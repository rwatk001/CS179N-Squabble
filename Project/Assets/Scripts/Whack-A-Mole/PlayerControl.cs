using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speed;
	//private float rotateSpeed;
	public GameObject player;
	public GameObject timerObject;
	private TimerControl timerControl;
	private Animator animator;
	
	enum direction {north, south, east, west};

	void Awake() {
		timerControl = timerObject.GetComponent<TimerControl> ();
		animator = GetComponent<Animator> ();
		//rotateSpeed = 1000f;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		if (!timerControl.gameEnded) {
			player.transform.Translate (-movement * speed * Time.deltaTime);

			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if (movement != Vector3.zero) {
				animator.SetBool("move", true);
			}
			else {
				animator.SetBool("move", false);
			}
			if (stateInfo.nameHash == Animator.StringToHash("Base Layer.Idle") || stateInfo.nameHash == Animator.StringToHash("Base Layer.Run")) {
			    if (Input.GetMouseButtonDown(0)) {
					animator.SetBool ("hit", true);
				}
				else {
					animator.SetBool ("hit", false);
				}
			}
		}
	}
}
