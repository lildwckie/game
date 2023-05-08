using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float minSpawnTime;
    public float maxSpawnTime;
    public GameObject[] obstaclePbs;
    public GameObject player;
    public BGLoop bgLoop;
    public bool isGameover;
    public bool isGamePlaying;
    private int m_score;

    public int Score { get => m_score; set => m_score = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();

        GameGUIManager.Ins.ShowGameGUI(false);
        GameGUIManager.Ins.UpdateScore(m_score);
    }

    public void PlayGame()
    {
        GameGUIManager.Ins.homeGui.SetActive(false);
        StartCoroutine(CoutingDown());
    }


    IEnumerator CoutingDown()
    {
        float time = 3f;

        GameGUIManager.Ins.UpdateTimeCounting(time);
        while(time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            GameGUIManager.Ins.UpdateTimeCounting(time);

        }

        isGamePlaying = true;

        if (player)
            player.SetActive(true);
        if(bgLoop)
            bgLoop.isStart = true;

        StartCoroutine(SpawnObstacle());
        GameGUIManager.Ins.ShowGameGUI(true);
    }

    


    IEnumerator SpawnObstacle()
    {
        while(!isGameover)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            if(obstaclePbs != null && obstaclePbs.Length > 0)
            {
                int obIdx = Random.Range(0, obstaclePbs.Length);

                GameObject obstacle = obstaclePbs[obIdx];

                if(obstacle)
                {
                    Vector3 spawnPos = new Vector3(
                        Random.Range(-1.4f, 1.4f), 8f, 0f);

                    Instantiate(obstacle, spawnPos, Quaternion.identity);
                }

            }
        }
    }
    public void GameOver()
    {
        isGameover = true;
        isGamePlaying = false;
        Prefs.bestScore = m_score;
        GameGUIManager.Ins.gameOverDialog.Show(true);
    }
}
