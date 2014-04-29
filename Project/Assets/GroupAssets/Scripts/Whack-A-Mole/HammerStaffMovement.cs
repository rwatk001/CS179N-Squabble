using UnityEngine;
using System.Collections;

public class HammerStaffMovement : MonoBehaviour {
	
	public GameObject hammer;
	private bool attackDown;
	private bool attackUp;
	private float hammerSpeed;
	private int count;

	// Use this for initialization
	void Start () {
		attackDown = false;
		attackUp = false;
		count = 0;
		hammerSpeed = 1000f;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			count = 0;
			attackDown = true;
			attackUp = false;
		}
		else if (Input.GetMouseButtonUp(0)) {
			attackDown = false;
			attackUp = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (attackDown && count < 6) {
			count = count + 1;
			hammer.transform.Rotate(Vector3.right * hammerSpeed * Time.deltaTime);
		}
		else if (attackUp && count < 12) {
			count = count + 1;
			hammer.transform.Rotate(Vector3.left * hammerSpeed * Time.deltaTime);
		}
	}
}
