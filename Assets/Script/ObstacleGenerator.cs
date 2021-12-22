using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    /// <summary>プレハブを格納</summary>
    [SerializeField]
    GameObject[] m_enemy;
    /// <summary>敵の生成インターバル</summary>
    [SerializeField]
    float m_interval = 0;
    /// <summary>経過時間</summary>
    float m_time = 0;
    [SerializeField] Transform[] _setPos = default;
    [SerializeField] GameObject _map = default;

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
            var pos = new Vector3(Random.Range(_setPos[0].position.x, _setPos[1].position.x), this.transform.position.y, 0);
            //インスタンス生成
            var obj = Random.Range(0, m_enemy.Length);
            Instantiate(m_enemy[obj], pos, Quaternion.identity, _map.transform);
            //経過時間をリセットして再度計測スタート
            m_time = 0f;
        }

    }
}
