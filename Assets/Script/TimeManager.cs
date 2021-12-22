using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    /// <summary>タイマー</summary>
    float _timer = 0;
    [SerializeField,Tooltip("ボスが出現するまでの時間")] 
    float _limitTime = 30f;
    void Start()
    {
        
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>_limitTime)
        {
            //タイムラインな流す
            //ジェネレーターを止める
        }
    }
}
