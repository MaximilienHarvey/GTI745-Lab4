using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class GameManager : Singleton<GameManager>
{
    private const string IntroScene = "Intro_Scene";
    private const string GameFlow = "Game_Flow";
    private const string EndScene = "End_Scene";
    
    [SerializeField] private int _noContrabandScore = 3;
    [SerializeField] private int _contrabandScore = 5;
    [SerializeField] private int _badLuggageScore = 3;
    [SerializeField] private HeartsController _heartsController;
    [SerializeField] private ScoreController _scoreController;
    
    [field: SerializeField] public int RemainingLives { get; private set; } = 3;

    [field: SerializeField] public int Score { get; private set; } = 0;

    private void Start()
    {
        _heartsController.RefreshHearts(RemainingLives);
        _scoreController.RefreshScore(Score);
    }

    public void AddLuggageWithoutContrabandScore()
    {
        Score += _noContrabandScore;
        _scoreController.RefreshScore(Score);
    }
    
    public void AddLuggageWithContrabandScore()
    {
        Score += _contrabandScore;
        _scoreController.RefreshScore(Score);
    }
    
    public void RemoveBadLuggageScore()
    {
        Score -= _badLuggageScore;
        _scoreController.RefreshScore(Score);
    }
    
    public void LoseLife()
    {
        RemainingLives = RemainingLives - 1;
        
        _heartsController.RefreshHearts(RemainingLives);
        
        if(RemainingLives <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game_Flow");
    }

    private void GameOver()
    {
        SceneManager.LoadScene(EndScene);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(IntroScene);
    }
}
