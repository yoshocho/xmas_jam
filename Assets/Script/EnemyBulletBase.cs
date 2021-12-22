using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 弾の基底クラス
/// </summary>
public class EnemyBulletBase : MonoBehaviour
{
     protected Transform _playerPos;
    protected PlayerScript _playerScript;
    [SerializeField, Tooltip("弾の速さ")]
    public int _bulletSpeed = 1;
    [SerializeField, Tooltip("弾のダメージ")]
    public int _bulletDamage = 1;
    void  Awake()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _playerScript = _playerPos.GetComponent<PlayerScript>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            _playerScript._hp.Value -= _bulletDamage;
            Debug.Log($"HPは{_playerScript._hp.Value}です");
        }
        else if (collision.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }

}
