using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;

    public void increaseScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }
}
 