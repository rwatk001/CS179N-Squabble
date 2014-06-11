using UnityEngine;
using System.Collections;

// Handles a tier of targets. When both targets have reached the end of their path, 
// they wait until the cooldown finishes before they move again
public class ShootoutManager :
    MonoBehaviour
{
    #region Fields
    // Left target
    public ShootoutTarget Left;
    // Right target
    public ShootoutTarget Right;

    // Minimum speed range
    public float SpeedMin;
    // Maximum speed range
    public float SpeedMax;

    #endregion
    
    #region Methods
    void Start()
    {
        // start targets moving
        Left.Speed = Random.Range(SpeedMin, SpeedMax);
        Right.Speed = -Random.Range(SpeedMin, SpeedMax);
        Right.GetComponent<Animator>().SetBool("running", true);
    }

    void Update()
    {
        // Both targets have reached the end of their path
        if (Left.Speed == 0 && Right.Speed == 0)
        {
            Left.Speed = Random.Range(SpeedMin, SpeedMax);
            Right.Speed = -Random.Range(SpeedMin, SpeedMax);
        }
    }
    #endregion

}

