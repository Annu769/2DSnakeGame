using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CO_OPGameOVerStates : MonoBehaviour
{
    [Header("Player Score Info")]
    [SerializeField] TextMeshProUGUI Player1ScoreText;
    [SerializeField] TextMeshProUGUI Player2ScoreText;
    [Header("Single Player Info")]
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI newHighScoreText;
    [Header("Multi Player Info")]
    [SerializeField] TextMeshProUGUI player1WonText;
    [SerializeField] TextMeshProUGUI player2WonText;
    [Header("Player Score Controller")]
    [SerializeField] ScoreUI player1_ScoreController;
    [SerializeField] ScoreUI player2_ScoreController;
    bool isplayer1won;
    bool isnewHighScore;

    enum GamePlay_Type
    {
        None,
        singlePlayer,
        MultiPlayer
    }
    [Header("GamePlay Type")]
    [SerializeField] GamePlay_Type gamePlay_Type;
    // Start is called before the first frame update
    void Awake()
    {
        if(player1WonText != null && player2WonText != null)
        {
            player1WonText.enabled = false;
            player2WonText.enabled = false;

        }
    }

    private void Start()
    {
        switch(gamePlay_Type)
        {
            case GamePlay_Type.singlePlayer:
                SinglePlayerState();
                break;
            case GamePlay_Type.MultiPlayer:
                MultiplayerState();
                break;

        }
    }

    // Update is called once per frame
    void SinglePlayerState()
    {
        Player1ScoreText.text = "Your Score : " + player1_ScoreController.GetScore();
        highScoreText.text = "HighScore : " + player1_ScoreController.GetHighScore();
        if(player1_ScoreController.GetScore() >= player1_ScoreController.GetHighScore())
        {
            isnewHighScore = true;
        }
        if(isnewHighScore == true )
        {
            newHighScoreText.enabled = true;
        }
        else
        {
            newHighScoreText.enabled = false;
        }
    }
    void MultiplayerState()
    {
        Player1ScoreText.text = "Player 1 : " + player1_ScoreController.GetScore();
        Player2ScoreText.text = "Player 2 : " + player2_ScoreController.GetScore();

        if (player1_ScoreController.GetScore() > player2_ScoreController.GetScore())
        {
            isplayer1won = true;
        }
        else if(player2_ScoreController.GetScore() > player1_ScoreController.GetScore())
        {
            isplayer1won = false;
        }
        else if(isplayer1won == true)
        {
            player1WonText.enabled = true;

        }
        else
        {
            player2WonText.enabled = true;
        }
    }
}
