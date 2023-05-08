using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDialog : Dialog
{
    public Text scoreText;
    public Text bestScoreText;

    private void Start()
    {
        if (scoreText)
            scoreText.text = GameManager.Ins.Score.ToString();
        if(bestScoreText)
            bestScoreText.text = Prefs.bestScore.ToString();
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
