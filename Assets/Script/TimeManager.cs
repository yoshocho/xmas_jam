using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UniRx;
public class TimeManager : MonoBehaviour
{
    /// <summary>タイマー</summary>
    float _timer = 0;
    [SerializeField,Tooltip("ボスが出現するまでの時間")] 
    float _limitTime = 30f;
    /// <summary>タイマーが動くためのフラグ</summary>
    bool isTimer = true;
    [SerializeField, Tooltip("ポーズマネージャー")] PauseManager _pauseManager;

    PlayerScript _player;
    void Start()
    {
        _pauseManager.OnPauseResume += TimerActive;
        _player.OnGameOver.Subscribe(_ => isTimer = false);
    }


    void Update()
    {
        if (isTimer)
        {
            _timer += Time.deltaTime;
        }
        
        if (_timer>_limitTime)
        {
            //タイムラインな流す
            //ジェネレーターを止める
            SceneManager.LoadSceneAsync("BossScene");
        }
    }

    void TimerActive(bool isActive)
    {
        isTimer = isActive;
    }
}
