using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : EnemyBulletBase
{
    void Start()
    {
        if (_playerPos.gameObject)
        {
            Vector2 v = _playerPos.position - this.transform.position;
            v = v.normalized * _bulletSpeed;

            // 速度ベクトルをセットする
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        else
        {
            // プレイヤーが居なかったら、すぐ消してしまう
            Destroy(this.gameObject);
        }
    }
}
