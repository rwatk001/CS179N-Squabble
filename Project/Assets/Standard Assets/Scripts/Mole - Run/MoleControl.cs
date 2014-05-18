using UnityEngine;
using System.Collections;

public class MoleControl : MonoBehaviour {
	
	private bool isMoleReady;
	private bool doesMoleStay;
	private bool isTimerDone;
	private float firstRand;
	private float secondRand;
	private float timerCount;
	private float moleAtop;
	private int colorRand;
	private int check;
	public int numHits;
	private int specialHits;
	private Animator animator;
	private Material[] moleMaterial = new Material[3];
	public static bool lostLifeGO = false;

	// Use this for initialization
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
		moleMaterial[0] = Resources.Load ("moleMat") as Material;
		moleMaterial[1] = Resources.Load ("badMoleMat") as Material;
		moleMaterial[2] = Resources.Load ("goodMoleMat") as Material;
	}

	void Update() {
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (isMoleReady && isTimerDone && stateInfo.nameHash == Animator.StringToHash("Base Layer.Mole Hide")) {
			firstRand = Random.Range (0, 100);
			secondRand = Random.Range (0, 100);
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

	private void assignColor (int num) {
		transform.Find ("polySurface2").renderer.material = moleMaterial[num];
	}

	private void moleReset () {
		animator.SetBool ("moleHit", true);
		animator.SetBool ("timeUp", true);
		isTimerDone = true;
		isMoleReady = true;
	}

}
