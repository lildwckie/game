using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGui;
    public GameObject gameGui;
    public Text timeCountingText;
    public Text scoreCountingText;
    public Dialog gameOverDialog;
    public Dialog pauseDialog;
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGUI(bool isShow)
    {
        if (gameGui)
        {
            gameGui.SetActive(isShow);
        }

        if(homeGui)
        {
            homeGui.SetActive(!isShow);
        }
    }

    public void UpdateTimeCounting(float time)
    {
        if (timeCountingText)
        {
            timeCountingText.gameObject.SetActive(true);
            timeCountingText.text = time.ToString();
            if (time <= 0)
            {
                timeCountingText.gameObject.SetActive(false);
            }
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreCountingText)
        {
            scoreCountingText.text = "Score : " + score.ToString(); //Score : 1234 
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        if(pauseDialog)
        {
            pauseDialog.Show(true);
        }
    }
}
