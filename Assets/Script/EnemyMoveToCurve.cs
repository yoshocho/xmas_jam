using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// まっすぐ下に移動し、プレイヤーに近づいたらその方向に曲げるように動かすコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMoveToCurve : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float _speed = 1f;
    /// <summary>プレイヤーよりどれくらい上で動きを変化するか</summary>
    [SerializeField] float _playerOffsetY = 5f;
    /// <summary>カーブする時にかける力</summary>
    [SerializeField] float _chasingPower = 1f;
    Rigidbody2D _rb;
    GameObject _player;
    /// <summary>曲がる方向</summary>
    float _x = 0f;

    void Start()
    {
        // まずまっすぐ下に移動させる
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.down * _speed;

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // プレイヤーがいない時は何もしない
        if (_player)
        {
            // プレイヤーとある程度近づいたら
            if (this.transform.position.y - _player.transform.position.y < _playerOffsetY)
            {
                // 左右どちらに曲がるか判定する
                if (_x == 0)
                {
                    _x = (_player.transform.position.x > this.transform.position.x) ? 1 : -1;   // m_x = 1 => 右方向、m_x = -1 => 左方向を「三項演算子」を使って計算している
                }

                // カーブする
                _rb.AddForce(_x * Vector2.right * _chasingPower);
            }
        }
    }
}