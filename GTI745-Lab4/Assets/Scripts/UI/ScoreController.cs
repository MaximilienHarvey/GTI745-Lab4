using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private const string SCORE_TEXT = "Score : ";
    
    public TMP_Text scoreText;
    
    public void RefreshScore(int score)
    {
        scoreText.text = SCORE_TEXT + score;
    }
}
