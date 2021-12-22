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

    int _keepScore = 0;

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
        CurrentGameState.DistinctUntilChanged()
            .Where(x => x == GameState.GAME_OVER)
            .Do(_ => ResetScore())
            .Subscribe(_ => _scoreSubJect.OnNext(_keepScore));    
    }

    void ResetScore()
    {
        _keepScore = _score;
        _score = 0;
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}
