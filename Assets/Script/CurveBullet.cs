using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーに近づいたらカーブする弾
/// </summary>
public class CurveBullet : EnemyBulletBase
{
    /// <summary>プレイヤーよりどれくらい上で動きを変化するか</summary>
    [SerializeField] float _playerOffsetY = 5f;
    /// <summary>カーブする時にかける力</summary>
    [SerializeField] float _chasingPower = 1f;
    Rigidbody2D _rb;

    /// <summary>曲がる方向</summary>
    float m_x = 0f;

    void Start()
    {
        // まずまっすぐ下に移動させる
        _rb = GetComponent<Rigidbody2D>();
        var v = _playerPos.position - this.transform.position;
        _rb.velocity = v.normalized * _bulletSpeed;
    }

    void Update()
    {
        // プレイヤーがいない時は何もしない
        if (_playerPos)
        {
            // プレイヤーとある程度近づいたら
            if (this.transform.position.y - _playerPos.position.y < _playerOffsetY)
            {
                // 左右どちらに曲がるか判定する
                if (m_x == 0)
                {
                    m_x = (_playerPos.position.x > this.transform.position.x) ? 1 : -1;   // m_x = 1 => 右方向、m_x = -1 => 左方向を「三項演算子」を使って計算している
                }

                // カーブする
                _rb.AddForce(m_x * Vector2.right * _chasingPower);
            }
        }
    }
}
