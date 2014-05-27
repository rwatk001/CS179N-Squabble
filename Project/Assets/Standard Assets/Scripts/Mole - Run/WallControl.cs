using UnityEngine;
using System.Collections;

public class WallControl : MonoBehaviour {

	public bool hitWall;
	public static int wallScore = 0;

	// Use this for initialization
	void Start () {
		hitWall = false;
	}

	void Update() {
		if (GameObject.Find ("Player").transform.position.z > transform.position.z+5) {
			KillBallControl.ballMove = true;
			++wallScore;
			Destroy(gameObject);
		}
		/*else if (TurnControl.turnCount == 1 && GameObject.Find ("Player").transform.position.x < transform.position.x-5) {
			++wallScore;
			Destroy(gameObject);
		}
		else if (TurnControl.turnCount == 2 && GameObject.Find ("Player").transform.position.z < transform.position.z-5) {
			++wallScore;
			Destroy(gameObject);
		}
		else if (TurnControl.turnCount == 3 && GameObject.Find ("Player").transform.position.x > transform.position.x+5) {
			++wallScore;
			Destroy(gameObject);
		}*/
	}
}
