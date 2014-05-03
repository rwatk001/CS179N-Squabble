using UnityEngine;
using System.Collections;

public class FroggerStart : 
    MonoBehaviour
{
    public float GameTimer = 3000;

	// From WAM ScoreContol
	public GUISkin playSkin;
	public GUISkin replaySkin;
	public GUISkin scoreSkin;
	private bool showScore = false;
	private float height;
	private float width;
	private float cushionHeight;
	private float cushionWidth;
	private int helpCount;
	// @@@@@@@@@@@@@@@@@@@@@@

    void Start()
    {
        GameObject trafficSpawner = Resources.Load<GameObject>("TrafficSpawner");
        GameObject checkPoint = Resources.Load<GameObject>("Checkpoint");

        int cpWeight = 0;
        int trafficWeight = 0;
        bool cpPrev = false;
        for (int lane = -19; lane < 20; lane += 2)
        {
            GameObject obj;
            int choice = Random.Range(1, 8) + cpWeight;
            if (choice < 7)
            {
                // Place Upward Spawner
                obj = Instantiate(trafficSpawner) as GameObject;
                if (choice <= 3)
                {
                    obj.GetComponent<TrafficSpawner>().TrafficVelocity = 5;
                    obj.transform.position = new Vector3(lane, obj.transform.position.y, -15);
                }
                else
                {                
                    obj.GetComponent<TrafficSpawner>().TrafficVelocity = -5;
                    obj.transform.position = new Vector3(lane, obj.transform.position.y, 15);
                }
                ++cpWeight;
                ++trafficWeight;
                cpPrev = false;
            }
            else if (!cpPrev)
            {
                obj = Instantiate(checkPoint) as GameObject;
                obj.GetComponent<FroggerCheckpoint>().ScoreMult = trafficWeight;
                obj.transform.position = new Vector3(lane, obj.transform.position.y, obj.transform.position.z);
                cpWeight = 0;
                trafficWeight = 0;
                cpPrev = true;
            }
            else
            {
                lane -= 2;
            }
        }

		// From WAM ScoreContol @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		showScore = false;
		height = Screen.height;
		width = Screen.width;
		cushionHeight = height * (float)0.10;
		cushionWidth = width * (float)0.10;
		helpCount = 0;
		// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    }

    void Update()
    {
        GameTimer -= Time.deltaTime;
        GameObject.Find("TimeDisplay").GetComponent<GUIText>().text = "Time: " + string.Format("{0:0.0}", (GameTimer));
        if (GameTimer <= 0)
        {
//            Time.timeScale = 0;
			showScore = true;
        }
    }

	// From WAM ScoreContol @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	private void OnGUI () {
		if (showScore) {
			GUI.BeginGroup (new Rect(0, 0, width, height));
			GUI.Box (new Rect(cushionWidth*3, cushionHeight, width*(float)0.40, height*(float)0.80), "");
			GUI.BeginGroup (new Rect (cushionWidth*3, cushionHeight, width, height));
			GUI.skin = scoreSkin;
			GUI.Label (new Rect (cushionWidth*(float)1.3, cushionHeight/2, width, height), "SCORE");
			helpCount = FroggerPlayer.score;
			GUI.Label (new Rect (cushionWidth*(float)1.4, cushionHeight*3, width, height), helpCount.ToString());
			GUI.skin = playSkin;
			if (GUI.Button (new Rect (cushionWidth*(float)2.5, cushionHeight*(float)6.50, 100, 50), "CONTINUE")) {
				Application.LoadLevel ("BarrelBreaker");
			}
			GUI.skin = replaySkin;
			if (GUI.Button (new Rect (cushionWidth*(float)0.75, cushionHeight*(float)6.50, 100, 50), "REPLAY")) {
				Application.LoadLevel ("Frogger");
			}
			GUI.EndGroup ();
			GUI.EndGroup ();
		}
	}
	// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}
