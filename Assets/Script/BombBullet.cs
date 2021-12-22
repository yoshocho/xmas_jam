using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : EnemyBulletBase
{
    [SerializeField,Tooltip("爆発のエフェクト")] 
    GameObject _bombEffectPrefub = default;
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
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (_bombEffectPrefub && collision.tag == "Player")
        {
            //Playerに触れたら爆発のエフェクトを出す
            var go = Instantiate(_bombEffectPrefub, this.transform.position, this.transform.rotation);
            Destroy(go, 3f);
        }
        else if (_bombEffectPrefub && collision.tag == "PlayerBullet")
        {
            //Playerの弾に触れたら爆発して自分も消す
            var go = Instantiate(_bombEffectPrefub, this.transform.position, this.transform.rotation);
            Destroy(go, 3f);
            Destroy(this.gameObject);
        }
        base.OnTriggerEnter2D(collision);
    }
}
