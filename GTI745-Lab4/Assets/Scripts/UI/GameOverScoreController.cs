using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverScoreController : MonoBehaviour
    {
        private const string SCORE_TEXT = "Score : ";
    
        public Text scoreText;

        private void Start()
        {
            scoreText.text = SCORE_TEXT + GameManager.Instance.Score;
        }
    }
}