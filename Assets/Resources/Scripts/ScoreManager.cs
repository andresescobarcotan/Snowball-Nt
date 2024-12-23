using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        if(score<0){
            score = 0;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Elfos: " + score;
        SceneData.playerScore = score;
    }
}
