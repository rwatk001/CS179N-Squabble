using UnityEngine;
using System.Collections;

// Manages the clip of the shooter
public class ShootoutCounter :
    MonoBehaviour
{
    public int ClipSize;        // Maximum number of shots
    public float ReloadLength;  // How long reloading takes

    int clip;                   // Number of shots remaining
    float reloadTime;           // Time to complete reload
    bool reloading;             // flag to check if reloading

    public bool Reloading
    {
        get { return reloading; }
    }

    public int Clip
    {
        get { return clip; }
    }

    void Start()
    {
        clip = ClipSize;
    }

    void Update()
    {
        // If reload is done, tick down reload
        if (reloadTime > 0)
        {
            reloadTime -= Time.fixedDeltaTime;
        }
        // If is reloading, reset clip to clipsize
        else if (reloading)
        {
            reloading = false;
            clip = ClipSize;
        }

        // Update ammo display
        for (int i = 0; i < ClipSize; ++i)
        {
            if (i + 1 <= clip)
                transform.FindChild("t" + i).transform.localScale = new Vector3(70, 70, 70);
            else
                transform.FindChild("t" + i).transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void Dec()
    {
        // Decrement clip count;
        --clip;
    }

    // Start reload
    public void Reload()
    {
        //Reload only when clip is exhausted
        if (!reloading && clip < 10)
        {
            reloading = true;
            reloadTime = ReloadLength;
        }
    }
}
