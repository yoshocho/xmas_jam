using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreText : MonoBehaviour
{
    [SerializeField] float _scoreInterval = 0.5f;
    [SerializeField] Text _scoreText = default;

    int _score = 0;
    GameManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        _manager = GameManager.Instance;
    }

    // Update is called once per frame

    public void AddScoreText(int score)
    {
        _score = _manager.Score;
        int tempScore = _score;
        _score = Mathf.Min(_score + score);
        
        DOTween.To(() => tempScore,
            x => tempScore = x,
            _score,
            _scoreInterval)
            .OnUpdate(() => _scoreText.text = tempScore.ToString("D8"))
            .OnStepComplete(() => _scoreText.text = _score.ToString("D8"));
    }
}
