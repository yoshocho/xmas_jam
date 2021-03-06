using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public enum GameState
{
    TILTE,
    INGAME,
    GAME_OVER
}
public class GameManager : Singleton<GameManager>
{
    int _score = 0;
    public int Score => _score;



    protected override void OnAwake()
    {
        base.OnAwake();
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}
