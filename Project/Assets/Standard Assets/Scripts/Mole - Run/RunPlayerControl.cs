using UnityEngine;
using System.Collections;

public class RunPlayerControl : MonoBehaviour {

	public GameObject player;
	public static bool ballHit = false;
	public static bool wallHit = false;
	private float moveHorizontal;
	private Vector3 newPosition;
	private Vector3 origin;
	private Vector3 tmpPosition;
	private float gravity;
	private float runningSpeed;
	private float jump;
	private bool beginJump;
	//private bool eastHit;
	//private bool westHit;

	// Use this for initialization
	void Start () {
		gravity = 30.0f;
		runningSpeed = 30.0f;
		jump = 5.0f;
		tmpPosition = Vector3.zero;
		beginJump = false;
		//eastHit = false;
		//westHit = false;
	}

	public void checkPosition () {
		if (newPosition.x <= 116.5f) {
			newPosition.x = 116.5f;
		}
		if (newPosition.x >= 135.0f) {
			newPosition.x = 135.0f;
		}
	}
	
	void FixedUpdate () {
		Plane playerPlane = new Plane (Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float hit;
		if (playerPlane.Raycast (ray, out hit) && !ballHit) {
			newPosition = ray.GetPoint (hit);
			checkPosition ();
			if (Input.GetMouseButtonDown (0)) {
				beginJump = true;
			}

			if (beginJump && transform.position.y == 0) {
				newPosition.y = jump;
			}
			else if (!beginJump) {
				newPosition.y = 0.0f;
			}
			else {
				tmpPosition.y -= gravity * Time.deltaTime;
				newPosition.y = tmpPosition.y;
				if (newPosition.y <= 0.0f) {
					newPosition.y = 0.0f;
					beginJump = false;
				}
			}
			Debug.Log (newPosition);
			if (!wallHit) {
				newPosition.z = transform.position.z + (runningSpeed * Time.deltaTime)	;
			}
			else {
				newPosition.z = transform.position.z;
			}

			tmpPosition = newPosition;
			float journey = 0.75f / Vector3.Distance (transform.position, newPosition);
			transform.position = Vector3.Lerp (transform.position, newPosition, journey);
		}
	}

	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "Wall") {
			wallHit = true;
		}
		/*else if (trigger.gameObject.tag == "East Wall") {
			eastHit = true;
		}
		else if (trigger.gameObject.tag == "West Wall") {
			westHit = true;
		}*/
		else if (trigger.gameObject.tag == "Kill Ball" && KillBallControl.ballMove) {
			//if (DataContainer.isPlayMode) {
				ballHit = true;
				transform.Translate(new Vector3(0.0f, -10.0f, 0.0f));
			//	--DataContainer.life;
			//}
			//else {
			//}
		}
		else if (trigger.gameObject.tag == "Empty") {
			//ballHit = true;
			transform.position = new Vector3(transform.position.x, -10.0f, transform.position.z);
		}
	}

	void OnTriggerExit (Collider trigger) {
		if (trigger.gameObject.tag == "Wall") {
			wallHit = false;
		}
		/*else if (trigger.gameObject.tag == "East Wall") {
			eastHit = false;
		}
		else if (trigger.gameObject.tag == "West Wall") {
			westHit = false;
		}*/
	}
}
