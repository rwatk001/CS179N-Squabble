using UnityEngine;
using System.Collections;

public class SpawnWallControl : MonoBehaviour {
	
	public Rigidbody wall;
	public GameObject player;
	private float loc;
	private float min;
	private float max;

	// Update is called once per frame
	void Update () {
		if (TurnControl.turnCount == 0) {
			min = -8.3f;
			max = 8.3f;
		}
		else if (TurnControl.turnCount == 1) {
			min = 73f;
			max = 91f;
		}
		else if (TurnControl.turnCount == 2) {
			min = -182f;
			max = -166f;
		}
		else {
			min = -100f;
			max = -84f;
		}
		loc = Random.Range (min, max);
		if (Random.Range (0, 50) == Random.Range (0, 50) && !RunPlayerControl.wallHit) {
			if (TurnControl.turnCount == 0) {
				Instantiate (wall, new Vector3(loc, 0.0f, player.transform.position.z+20), Quaternion.identity);
			}
			else if (TurnControl.turnCount == 1) {
				Instantiate (wall, new Vector3(player.transform.position.x-20, 0.0f, loc), player.transform.rotation);
			}
			else if (TurnControl.turnCount == 2) {
				Instantiate (wall, new Vector3(loc, 0.0f, player.transform.position.z-20), Quaternion.identity);
			}
			else {
				Instantiate (wall, new Vector3(player.transform.position.x+20, 0.0f, loc), player.transform.rotation);
			}
		}
	}
}