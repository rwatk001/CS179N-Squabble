using UnityEngine;
using System.Collections;

// Controls the frogger player avatar
public class FroggerPlayer : 
    MonoBehaviour 
{
    public float Speed;
    public static float Startpoint;
    public static float Checkpoint;
	public static bool playerHit;

    public static int Score;

    Vector3 moveTo;
    float moveDist;
    float startTime;

	// Use this for initialization
	void Start () {
        moveTo = transform.position;
        Startpoint = transform.position.x;
        Checkpoint = transform.position.x;
		playerHit = false;
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !playerHit && !TimerControl.gameEnded)
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                startTime = Time.time;                
                moveTo = ray.GetPoint(hitdist);
                moveDist = Vector3.Distance(transform.position, moveTo);
                Quaternion targetRotation = Quaternion.LookRotation(moveTo - transform.position);
                transform.rotation = targetRotation;
            }
        }

		if (transform.position != moveTo && GameObject.Find("Floor").GetComponent<FroggerStart>().GameTimer > 0 && !playerHit)
        {
            float distCovered = (Time.time - startTime) * Speed;            
            GetComponent<Animator>().SetBool("running", true);
            if (distCovered / moveDist < 0.9f)
                transform.position = Vector3.Lerp(transform.position, moveTo, distCovered / moveDist);
            else
                transform.position = Vector3.Lerp(transform.position, moveTo, 1);
        }
        else
        {
            GetComponent<Animator>().SetBool("running", false);
        }
        //GameObject.Find("Score").GetComponent<GUIText>().text = "Score: " + Score;
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Car")
        {
            collider.audio.Play();
            transform.position = new Vector3(Checkpoint, transform.position.y, transform.position.z);
            moveTo = transform.position;

            if (!DataContainer.isPlayMode) {
            	--Score;
				--TimerControl.scoreCount;
			}
        }
        
        if (collider.tag == "Bus")
        {
            collider.audio.Play();
            audio.Play();

            GameObject hitPart = Instantiate(Resources.Load<GameObject>("squubhit")) as GameObject;
            hitPart.transform.position = this.transform.position;            
            Destroy(hitPart, 1);

            if (DataContainer.isPlayMode)
            {
                // GAME OVER
                --DataContainer.life;
                transform.position = new Vector3(0, -10, 0);
				playerHit = true;
            }
            else
            {
                transform.position = new Vector3(Startpoint, transform.position.y, transform.position.z);
                Checkpoint = Startpoint;
                moveTo = transform.position;
				Score -= 10;
                TimerControl.scoreCount -= 10;
            }
        }

        FroggerCheckpoint check = collider.GetComponent<FroggerCheckpoint>();
        if (check != null)
        {
            if (check.transform.position.x != Checkpoint) {
                //Score += check.ScoreMult;
				TimerControl.scoreCount += check.ScoreMult;
				DataContainer.finalScore += check.ScoreMult;
			}
            Checkpoint = collider.transform.position.x;
        }

        if (collider.tag == "Finish")
        {
        	Score += 10;
			TimerControl.scoreCount += 10;
			DataContainer.finalScore += 10;
            transform.position = new Vector3(Startpoint, transform.position.y, transform.position.z);
            Checkpoint = Startpoint;
            moveTo = transform.position;
        }
    }
}
