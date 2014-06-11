using UnityEngine;
using System.Collections;


public class ShootoutTarget :
    MonoBehaviour
{
    public float Length;
    public float Speed;
    public bool IsTarget;
	public static bool playerHit;

    Vector3 origin;

    // Calculates the distance travelled by this target from its initial position
    public float DistanceTravelled
    {
        get { return transform.position.magnitude - origin.magnitude; }
    }

    void Start()
    {
        // Sets the initial position to where this target starts
        origin = transform.position;
		playerHit = false;
    }

    void Update()
    {
        // If the target has reached the end of its path, return to initial position
        if (transform.position.magnitude - origin.magnitude >= Length)
            Reset();

        // If the game has not stopped, move this target
        if(!TimerControl.gameEnded)
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check if a shot hit this target
        if (collider.tag == "Arrow")
        {
            GameObject hitsoundSource = new GameObject("hitsound");
            hitsoundSource.transform.position = transform.position;
            hitsoundSource.AddComponent<AudioSource>();
            hitsoundSource.GetComponent<AudioSource>().clip = audio.clip;
            hitsoundSource.GetComponent<AudioSource>().Play();

            // The player hit a sheep
            if (IsTarget)
            {
                GameObject hitPart = Instantiate(Resources.Load<GameObject>("sheephit")) as GameObject;
                hitPart.transform.position = this.transform.position;
                Reset();
                Destroy(hitPart, 1);
                Destroy(collider);

                //GameObject.Find("Score").GetComponent<GUIText>().text = "Score: " + ++ShootoutShooter.Score;
				++ShootoutShooter.Score;
				++DataContainer.finalScore;
				++TimerControl.scoreCount;
            }
            // The player hit a civilian, oh noes!
            else
            {
                GameObject hitPart = Instantiate(Resources.Load<GameObject>("squubhit")) as GameObject;
                hitPart.transform.position = this.transform.position;
                Reset();
                Destroy(hitPart, 1);
                Destroy(collider);

                if (DataContainer.isPlayMode)
                {
                    --DataContainer.life;
					playerHit = true;
                }
                else
                {
                    //GameObject.Find("Score").GetComponent<GUIText>().text = "Score: " + --ShootoutShooter.Score;
					--ShootoutShooter.Score;
					--TimerControl.scoreCount;
                }                
            }
        }
    }
    
    // Resets the target to its initial position and freezes it
    public void Reset()
    {
        Speed = 0f;
        transform.position = origin;
    }
}

