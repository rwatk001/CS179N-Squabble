using UnityEngine;
using System.Collections;

public class ShootoutShooter :
    MonoBehaviour
{
    //public ShootoutCounter ClipCounter; //Object to track the amount of shots remaining
    public GameObject Crosshair;        //Crosshair for aiming
    public float GameTimer = 31;        //Time until game is finished
    
    public static int Score = 0;

    void Start()
    {
        // Safety measure to ensure the game runs when reset
        Time.timeScale = 1;
		Score = 0;
    }

    void Update()
    {
        if (SplashScreen.gameGO)
        {
            GameTimer -= Time.deltaTime;
            if (GameTimer <= 0)
            {
                // If time's up, freeze the game
				TimerControl.gameEnded = true;
            }
        }

        // Move the crosshair in relation to the mouse
        Crosshair.transform.position = new Vector3(12 * (Input.mousePosition.x / Screen.width) - 6, Input.mousePosition.y / Screen.height * 5, Input.mousePosition.y / Screen.height * 5  - 4);
        //if (!ClipCounter.Reloading)
        //{
            // If the player clicks the left button
            if (Input.GetMouseButtonDown(0) && !TimerControl.gameEnded)
            {
        //        // Out of ammo
        //        if (ClipCounter.Clip <= 0)
        //        {
        //            ClipCounter.Reload();
        //        }
        //        // FIRE!!!
        //        else
        //        {
                    Vector3 tomatoPos = new Vector3(12 * (Input.mousePosition.x / Screen.width) - 6, 2, -8);
                    GameObject tomato = Instantiate(Resources.Load<GameObject>("Tomato"), tomatoPos, Quaternion.identity) as GameObject;
                    float pitch = (Input.mousePosition.y / Screen.height) * 10;
                    if (pitch <= 2)
                        pitch = 0;
                    tomato.rigidbody.velocity = new Vector3(0, pitch, 10);
                    Destroy(tomato, 5);
                    //ClipCounter.Dec();
            //    }
            }
            //// Right mouse click, reload
            //else if (Input.GetMouseButtonDown(1))
            //{
            //    ClipCounter.Reload();
            //}
        //}
    }
}

