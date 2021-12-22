using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class ScoreRaking : MonoBehaviour
{
    [SerializeField] Text _firstRakingScore = default;
    [SerializeField] Text _secondRakingScore = default;
    [SerializeField] Text _thirdRakingScore = default;
    int[] _rakingScore = new int[4] {0,0,0,0};

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //_firstRakingScore = GetComponent<Text>();
        //_secondRakingScore = GetComponent<Text>();
        //_thirdRakingScore = GetComponent<Text>();
        gameManager = GameManager.Instance;
        RankingText();
        gameManager.CurrentGameState
            .DistinctUntilChanged()
            .Where(_ => _ == GameState.RESULT)
            .Subscribe(_ => RankingText());
        
    }

    
    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < _rakingScore.Length; i++)
        //{
        //    if (gameManager.Score > _rakingScore[i])
        //    {
        //        _rakingScore[i] = gameManager.Score;
        //    }
        //}
    }

    void RankingText()
    {
        _rakingScore[0] = gameManager.Score;
        Array.Sort(_rakingScore);
        _firstRakingScore.text = "1位:" + _rakingScore[3];
        _secondRakingScore.text = "2位:" + _rakingScore[2];
        _thirdRakingScore.text = "3位:" + _rakingScore[1];

    }
}
