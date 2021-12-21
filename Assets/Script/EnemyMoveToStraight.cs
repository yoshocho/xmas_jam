using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトをまっすぐ一方向に移動させる
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMoveToStraight : MonoBehaviour
{
    /// <summary>移動する方向</summary>
    [SerializeField] Vector2 _direction = Vector2.down;
    /// <summary>移動する速度</summary>
    [SerializeField] float _speed = 1.5f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // 指定した方向に指定した速度で動かす
        _rb.velocity = _direction.normalized * _speed;
    }
}