using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    int score = 0;
    int highScore;
    // Start is called before the first frame update
    void Start()
    {
        if(highScoreText != null)
        {
            highScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore :", 0).ToString();
        }
    }

    // Update is called once per frame
    public void AddScore(int IncreasScore)
    {
        score += IncreasScore;
        scoreText.text = "Score : " + score;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore :", 0);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore :", score);
            PlayerPrefs.Save();
            if(highScoreText !=null)
            {
                highScoreText.text = "HighScore : " + score.ToString();
            }
        }
        return highScore;
    }
}
