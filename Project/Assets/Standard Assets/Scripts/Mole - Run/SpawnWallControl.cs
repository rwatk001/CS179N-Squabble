using UnityEngine;
using System.Collections;

public class SpawnWallControl : MonoBehaviour {
	
	public Rigidbody wall;
	public GameObject player;
	public GameObject travelSheep;
	private float loc;
	private float alongX;
	private float alongZ;
	private float distance;
	private int switcher;
	private Vector3 position;
	private Quaternion rotation;
	
	void Start () {
		loc = 0;
		distance = 30;
		alongX = 0;
	}

	// Update is called once per frame
	void Update () {
		//sheepSpawn ();
		wallSpawn ();
	}

	public void sheepSpawn () {
		if (TurnControl.turnCount == 0) {
			//while (GameObject.Find  ("Sheep(Clone)") != null) {
			if (-8.3f + alongX <= 10) {
				alongX += 1.7f;
				position = new Vector3 (-8.3f + alongX, 0.8f, player.transform.position.z+20);
				rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				Instantiate (travelSheep, position, rotation);
			}
			//}
		}
		else if (TurnControl.turnCount == 1) {
		}
		else if (TurnControl.turnCount == 2) {
		}
		else {
		}

	}

	public void wallSpawn () {
		/*switcher = Random.Range (0, 2);
		if (TurnControl.turnCount == 0) {
			if (switcher == 0) {
				min = -5.0f;
				max = -1.0f;
			}
			else {
				min = 1.0f;
				max = 5.0f;
			}
		}
		else if (TurnControl.turnCount == 1) {
			if (switcher == 0) {
				min = 76.0f;
				max = 81.0f;
			}
			else {
				min = 82.0f;
				max = 87.0f;
			}
		}
		else if (TurnControl.turnCount == 2) {
			if (switcher == 0) {
				min = -168.0f;
				max = -173.0f;
			}
			else {
				min = -175.0f;
				max = -180.0f;
			}
		}
		else {
			if (switcher == 0) {
				min = -86.0f;
				max = -91.0f;
			}
			else {
				min = -93.0f;
				max = -98.0f;
			}
		}*/
		loc = Random.Range (121.0f, 131.0f);
		if (Random.Range (0, 25) == Random.Range (0, 25) && !RunPlayerControl.wallHit && !RunPlayerControl.ballHit) {
			/*if (TurnControl.turnCount == 0) {
				if (player.transform.position.z + distance <= 80) {
					Instantiate (wall, new Vector3(loc, 0.0f, player.transform.position.z+distance), Quaternion.identity);
				}
			}
			else if (TurnControl.turnCount == 1) {
				if (player.transform.position.x - distance >= -166) {
					Instantiate (wall, new Vector3(player.transform.position.x-distance, 0.0f, loc), player.transform.rotation);
				}
			}
			else if (TurnControl.turnCount == 2) {
				if (player.transform.position.z - distance >= -87) {
					Instantiate (wall, new Vector3(loc, 0.0f, player.transform.position.z-distance), Quaternion.identity);
				}
			}
			else {
				if (player.transform.position.x + distance <= -3) {
					Instantiate (wall, new Vector3(player.transform.position.x+distance, 0.0f, loc), player.transform.rotation);
				}
			}*/
			Instantiate (wall, new Vector3(loc, 0.0f, player.transform.position.z+distance), Quaternion.identity);
		}
	}
}