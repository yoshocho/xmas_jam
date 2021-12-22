using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    /// <summary>タイマー</summary>
    float _timer = 0;
    [SerializeField,Tooltip("ボスが出現するまでの時間")] 
    float _limitTime = 30f;
    /// <summary>タイマーが動くためのフラグ</summary>
    bool isTimer = true;
    [SerializeField, Tooltip("ポーズマネージャー")] PauseManager _pauseManager;
    void Start()
    {
        _pauseManager.OnPauseResume += TimerActive;
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
        }
    }

    void TimerActive(bool isActive)
    {
        isTimer = isActive;
    }
}
