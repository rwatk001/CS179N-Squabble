using UnityEngine;
using System.Collections;

public class HammerPalletMovement : MonoBehaviour {

	public GameObject pallet;
	private int count;
	private bool attackDown;
	private bool attackUp;
	private float hammerSpeed;

	// Use this for initialization
	void Start () {
		count = 0;
		attackDown = false;
		attackUp = false;
		hammerSpeed = 100;
	}
	
	// Update is called once per frame
	void Update () {
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
		
	void FixedUpdate() {
		if (attackDown && count < 6) {
			count = count + 1;
			pallet.transform.RotateAround (Vector3.zero, Vector3.right, hammerSpeed * Time.deltaTime);
		}
		else if (attackUp && count < 12) {
			count = count + 1;
			pallet.transform.RotateAround (Vector3.zero, Vector3.left, hammerSpeed * Time.deltaTime);
		}
	}
}
