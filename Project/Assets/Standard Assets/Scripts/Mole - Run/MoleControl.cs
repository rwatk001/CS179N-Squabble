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
	private int specialHits;
	private Animator animator;
	private Material[] moleMaterial = new Material[3];

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
		specialHits = 0;
		// there will be different moles worth different amount of points
		// the visual representation will be as different materials
		moleMaterial[0] = Resources.Load ("moleMat") as Material;
		moleMaterial[1] = Resources.Load ("badMoleMat") as Material;
		moleMaterial[2] = Resources.Load ("goodMoleMat") as Material;
	}

	// Update ()
	void Update() {
		// access the animation for the moles
		// basic animation is to show the player is they hit the mole or nor
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (isMoleReady && isTimerDone && stateInfo.nameHash == Animator.StringToHash("Base Layer.Mole Hide")) {
			firstRand = Random.Range (0, 1000);
			secondRand = Random.Range (0, 1000);
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
				assignColor (colorRandFunc());
			}
			else {
				animator.SetBool ("moleReady", false);
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
			if (check == 1) {
				if (DataContainer.isPlayMode) {
					lostLifeGO = true;
					--DataContainer.life;
				}
				else {
					numHits -= 1;
				}
				moleReset();
			}
			// the gold mole takes two hits to get the points
			// can be changed by assuming a different specialHits
			else if (check == 2) {
				++specialHits;
				if (specialHits == 2) {
					specialHits = 0;
					numHits += 5;
					moleReset();
				}
			}
			else {
				numHits += 1;
				moleReset();
			}
		}
	}

	// random moles spawn and colorRandFunc() 
	// determines what type of mole is spawning
	private int colorRandFunc () {
		colorRand = Random.Range (1, 101);
		if (colorRand < 81) {
			check = 0;
			return 0;
		}
		else if (colorRand > 80 && colorRand < 96) {
			check = 1;
			return 1;
		}
		else {
			check = 2;
			return 2;
		}
	}

	// assigns the color to the mole when it is ready to spawn
	private void assignColor (int num) {
		transform.Find ("polySurface2").renderer.material = moleMaterial[num];
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
