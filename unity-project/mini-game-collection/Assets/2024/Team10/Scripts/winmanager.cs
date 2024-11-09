using MiniGameCollection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winmanager : MonoBehaviour
{

    public GameObject miniGameScore;
    public MiniGameScoreUI scoreUI;
    public GameObject miniGameManager;
    public MiniGameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        scoreUI = miniGameScore.GetComponent<MiniGameScoreUI>();
        manager = miniGameManager.GetComponent<MiniGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreUI.PlayerScores[0] > scoreUI.PlayerScores[1])
        {
            manager.Winner = MiniGameWinner.Player1;
        }

        else if (scoreUI.PlayerScores[0] < scoreUI.PlayerScores[1])
        {
            manager.Winner = MiniGameWinner.Player2;
        }

        else if (scoreUI.PlayerScores[0] == scoreUI.PlayerScores[1])
        {
            manager.Winner = MiniGameWinner.Draw;
        }
    }
}
