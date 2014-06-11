// ANDREW LEGASPINO

using UnityEngine;
using System.Collections;

public class MoleControl : MonoBehaviour {

	// public and private variable needed
	// to control the functionality of the moles
	public static bool lostLifeGO = false;
	public int numHits;
	private bool isMoleReady;
	private bool doesMoleStay;
	private bool isTimerDone;
	private float firstRand;
	private float secondRand;
	private float timerCount;
	private float moleAtop;
	private int colorRand;
	private int check;
	private Animator animator;

	// Start ()
	void Start () {
		animator = GetComponent<Animator> ();
		isMoleReady = true;
		doesMoleStay = false;
		isTimerDone = true;
		firstRand = 0;
		secondRand = 0;
		timerCount = 0;
		numHits = 0;
	}

	// Update ()
	void Update() {
		// access the animation for the moles
		// basic animation is to show the player is they hit the mole or nor
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (isMoleReady && isTimerDone && stateInfo.nameHash == Animator.StringToHash("Base Layer.Mole Hide") 
		    && SplashScreen.gameGO) {
			firstRand = Random.Range (0, 500);
			secondRand = Random.Range (0, 500);
			// randomly spawns the mole
			// the firstRand and secondRand variables determine
			// the frequency of spawining moles. I set it to a low frequency
			// to increase urgency and difficulty in the game
			if (firstRand == secondRand) {
				lostLifeGO = false;
				isMoleReady = false;
				isTimerDone = false;
				animator.SetBool ("moleHit", false);
				animator.SetBool ("timeUp", false);
				animator.SetBool ("moleReady", true);
				moleAtop = Random.Range (0, 10);
				doesMoleStay = true;
				this.GetComponent<BoxCollider> ().enabled = true;
			}
			else {
				animator.SetBool ("moleReady", false);
				this.GetComponent<BoxCollider> ().enabled = false;
			}
		}
		// the time the mole stays above the ground is also random
		// it can stay up for a while or a quick second
		// adds to the complexity to the game
		if (doesMoleStay && stateInfo.nameHash == Animator.StringToHash("Base Layer.Mole Stay")) {
			timerCount += Time.deltaTime;
			if (timerCount >= moleAtop) {
				animator.SetBool ("timeUp", true);
				doesMoleStay = false;
				timerCount = 0;
				isTimerDone = true;
				isMoleReady = true;
			}
		}
	}

	// the mole checks to see if a hammer has hit it
	// depending in the game mode then 
	// in "Play Mode" you cannot get hit by a sheep or
	// hit a red mole. This causes you to lose a life
	// OnTriggerEnter () checks the game mode and any
	// collisions to appropriate move the game
	void OnTriggerEnter (Collider trigger) {
		if (trigger.gameObject.tag == "Hammer") {
            audio.Play();
			++numHits;
			++DataContainer.finalScore;
			++TimerControl.scoreCount;
			moleReset();
		}
	}

	// if the mole time is up or the player successfully hits the mole
	// then the mole goes back into the ground and the 
	// process repeats itself
	private void moleReset () {
		animator.SetBool ("moleHit", true);
		animator.SetBool ("timeUp", true);
		isTimerDone = true;
		isMoleReady = true;
	}
}
