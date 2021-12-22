using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGenerator : MonoBehaviour
{
    /// <summary>プレハブを格納</summary>
    [SerializeField]
    public GameObject m_enemy;
    /// <summary>敵の生成インターバル</summary>
    [SerializeField]
    public float m_interval = 0;
    /// <summary>経過時間</summary>
    [SerializeField]
    public float m_time = 0;
    [SerializeField] PauseManager _pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        m_interval = 3f;
        _pauseManager.OnPauseResume += SelfEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        m_time += Time.deltaTime;
        EnemyGenerate();
    }
    public void EnemyGenerate()
    {
        //経過時間が生成時間になった時
        if (m_time > m_interval)
        {
            //インスタンス生成
            Instantiate(m_enemy, transform.position, Quaternion.identity);
            //経過時間をリセットして再度計測スタート
            m_time = 0f;
        }

    }
    void SelfEnabled(bool isactive)
    {
        this.enabled = isactive;
    }
}
