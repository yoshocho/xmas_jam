using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 弾の基底クラス
/// </summary>
public class EnemyBulletBase : MonoBehaviour
{
     protected Transform _playerPos;
    [SerializeField, Tooltip("弾の速さ")] public int _bulletSpeed = 1;
    void  Awake()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag =="Finish")
        {
            //プレイヤーコントローラーを呼んできてスコアを追加
            Destroy(this.gameObject);
        }
    }

}
