using UnityEngine;
using Utilities;

public class GameManager : Singleton<GameManager>
{
    
    [SerializeField] private int _noContrabandScore = 3;
    [SerializeField] private int _contrabandScore = 5;
    
    public int RemainingLives { get; private set; } = 3;
    
    public int Score { get; private set; }
    
    public void AddLuggageWithoutContrabandScore()
    {
        Score += _noContrabandScore;
    }
    
    public void AddLuggageWithContrabandScore()
    {
        Score += _contrabandScore;
    }
    
    public void LoseLife()
    {
        RemainingLives--;
    }
}
