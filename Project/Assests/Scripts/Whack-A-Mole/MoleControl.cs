using UnityEngine;
using System.Collections;

public class MoleControl : MonoBehaviour {
	
	private bool isMoleReady;
	private bool isMoleAboveGround;
	private bool doesMoleStay;
	private bool isTimerDone;
	private float firstRand;
	private float secondRand;
	private float timerCount;
	private float moleSpeed;
	private float moleAtop;
	public int numHits;
	private Vector3 originPosition;
	public GameObject mole;

	// Use this for initialization
	void Start () {
		isMoleReady = false;
		isMoleAboveGround = false;
		doesMoleStay = false;
		isTimerDone = true;
		firstRand = 0;
		secondRand = 0;
		timerCount = 0;
		moleSpeed = 0;
		moleAtop = 0;
		originPosition = transform.position;
	}

	void Update() {
		if (!isMoleReady && isTimerDone) {
			firstRand = Random.Range (0, 100);
			secondRand = Random.Range (0, 100);
			if (firstRand == secondRand) {
				isMoleReady = true;
				moleSpeed = Random.Range (2, 3);
				moleAtop = Random.Range (0, 10);
			}
			else {
				doesMoleStay = true;
				isTimerDone = false;
			}
		}
		if (doesMoleStay) {
			timerCount += 1;
			if (timerCount >= moleAtop) {
				doesMoleStay = false;
				if (isMoleAboveGround) {
					isMoleAboveGround = false;
				}
				else {
					isMoleAboveGround = true; 
				}
				timerCount = 0;
				isTimerDone = true;
			}
		}	
	}

	void FixedUpdate () {
		if (!doesMoleStay && isMoleReady) {
			if (!isMoleAboveGround && mole.transform.position.y < 0) {
				doesMoleStay = false;
				mole.transform.Translate (Vector3.up * moleSpeed * Time.deltaTime);
			}
			else if (isMoleAboveGround && mole.transform.position.y > -1) {
				doesMoleStay = false;
				mole.transform.Translate (Vector3.down * moleSpeed * Time.deltaTime);
			} 
			else {
				doesMoleStay = true;
				isMoleReady = false;
			}
		}
	}

	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "Hammer") {
			numHits += 1;
			mole.transform.position = originPosition;
			doesMoleStay = true;
			isMoleReady = false;
			//Debug.Log ("HIT");
		}
	}
}
