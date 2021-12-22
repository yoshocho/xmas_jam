using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

public class ScoreRaking : MonoBehaviour
{
    [SerializeField] Text _firstRankingScore = default;
    [SerializeField] Text _secondRankingScore = default;
    [SerializeField] Text _thirdRankingScore = default;
    [SerializeField] Text _yourScore = default;
    int[] _rankingScore = new int[4] {0,0,0,0};

    GameManager gameManager;

    void Start()
    {
        //_firstRakingScore = GetComponent<Text>();
        //_secondRakingScore = GetComponent<Text>();
        //_thirdRakingScore = GetComponent<Text>();
        gameManager = GameManager.Instance;
        RankingText();
    }

    void Update()
    {
       
    }

    void RankingText()
    {
        _rankingScore[0] = gameManager.Score;
        Array.Sort(_rankingScore);
        _firstRankingScore.text = "1位:" + _rankingScore[3].ToString("D8");
        _secondRankingScore.text = "2位:" + _rankingScore[2].ToString("D8");
        _thirdRankingScore.text = "3位:" + _rankingScore[1].ToString("D8");
        _yourScore.text = gameManager.Score.ToString("D8");

    }
}
