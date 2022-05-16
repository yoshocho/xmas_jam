using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public enum GameState 
{
    TILTE,
    IN_GAME,
    GAME_OVER,
    RESULT,
}

public class GameManager : Singleton<GameManager>
{
    int _score = 0;
    public int Score => _score;
    public ReactiveProperty<GameState> CurrentGameState = new ReactiveProperty<GameState>();

    Subject<int> _scoreSubJect = new Subject<int>();
    IObservable<int> GameScore => _scoreSubJect;

    protected override void OnAwake()
    {
        base.OnAwake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
       
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}
