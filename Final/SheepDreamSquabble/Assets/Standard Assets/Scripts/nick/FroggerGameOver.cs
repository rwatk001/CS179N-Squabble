using UnityEngine;
using System.Collections;

public class FroggerGameOver : 
    MonoBehaviour
{
    public GUISkin playSkin;
    public GUISkin replaySkin;
    public GUISkin scoreSkin;
    public GUISkin menuSkin;
    private bool showScore;
    private float height;
    private float width;
    private float cushionHeight;
    private float cushionWidth;
    private int scoreCount;

	void Awake () {
		height = Screen.height;
		width = Screen.width;
		cushionWidth = width * 0.10f;
		cushionHeight = height * 0.10f;
	}

    public void reloadReset()
    {
		FroggerPlayer.playerHit = false;
		TimerControl.gameEnded = false;
    }

    private void OnGUI()
    {
        if (TimerControl.gameEnded)
        {
            GUI.BeginGroup(new Rect(0, 0, width, height));
            GUI.Box(new Rect(cushionWidth * 3, cushionHeight, width * (float)0.40, height * (float)0.80), "");
            GUI.BeginGroup(new Rect(cushionWidth * 3, cushionHeight, width, height));
            GUI.skin = scoreSkin;
            GUI.Label(new Rect(cushionWidth * (float)1.3, cushionHeight / 2, width, height), "SCORE");
            // determines which score is going to be displayed            
            if (DataContainer.isPlayMode) {
				scoreCount = DataContainer.finalScore;
			}
			else {
				scoreCount = TimerControl.scoreCount;
			}
            
            // "Train Mode" allows you to go back and choose other levels to practice
            // before taking on "Play Mode"
            GUI.Label(new Rect(cushionWidth * (float)1.8, cushionHeight * 3, width, height), scoreCount.ToString());
            if (!DataContainer.isPlayMode)
            {
                GUI.skin = menuSkin;
                if (GUI.Button(new Rect(cushionWidth * (float)2.5, cushionHeight * (float)6.50, 100, 50), "BACK"))
                {
                    reloadReset();
                    Application.LoadLevel("TrainMenuList");
                }
                GUI.skin = replaySkin;
                // "Train Mode" also gives you the option to replay the level at the end
                // for any reason
                if (GUI.Button(new Rect(cushionWidth * (float)0.75, cushionHeight * (float)6.50, 100, 50), "REPLAY"))
                {
                    reloadReset();
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
            // displays the final score and reverts you back to the main title screen
            else if (DataContainer.gameOver)
            {
                GUI.skin = playSkin;
                if (GUI.Button(new Rect(cushionWidth * (float)1.8, cushionHeight * (float)6.50, 100, 50), "FINISH"))
                {
                    reloadReset();
                    Application.LoadLevel("GameEnd");
                }
            }
            // part of "Play Mode" that you can only move forward
            // displays the right score and the next level is predetermined by the DataContainer script
            else
            {
                GUI.skin = playSkin;
                if (GUI.Button(new Rect(cushionWidth * 1.8f, cushionHeight * (float)6.50, 100, 50), "CONTINUE"))
                {
                    reloadReset();
                    if (Application.loadedLevel == DataContainer.level_1)
                    {
                        Application.LoadLevel(DataContainer.level_2);
                    }
                    else if (Application.loadedLevel == DataContainer.level_2)
                    {
                        Application.LoadLevel(DataContainer.level_3);
                    }
                    else if (Application.loadedLevel == DataContainer.level_3)
                    {
                        Application.LoadLevel(DataContainer.level_4);
                    }
                    else if (Application.loadedLevel == DataContainer.level_4)
                    {
                        Application.LoadLevel(DataContainer.level_5);
                    }
                    else if (Application.loadedLevel == DataContainer.level_5) {
                        Application.LoadLevel(DataContainer.level_6);
                    }
                    else if (Application.loadedLevel == DataContainer.level_6) {
                        DataContainer.AssignLevel();
                        Application.LoadLevel (DataContainer.level_1);
                    }
                }
            }
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }
}
