using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] string _destroyAreaName = "Finish";
    [SerializeField] EnemyBulletBase[] _bullets = default;
    [SerializeField] Transform[] _instancePos = default;

    private void Awake()
    {
        var c = this.gameObject.GetComponent<CapsuleCollider2D>();
        c.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_destroyAreaName))
        {
            Destroy(this.gameObject);
        }
    }
    public void CreateBullet()
    {
        if (_bullets[0])
        {
            if (_instancePos[0])
            {
                for (int i = 0; i < _instancePos.Length; i++)
                {
                    var bulletRange = Random.Range(0, _bullets.Length);//弾とポジションをランダムで決める
                    //var posRange = Random.Range(0, _instancePos.Length);
                    Instantiate(_bullets[bulletRange], _instancePos[i].position, Quaternion.identity);
                }
            }
            else//発射地点が何も設定されていない
            {
                for (int i = 0; i < _bullets.Length; i++)
                {
                    var bulletRange = Random.Range(0, _bullets.Length + 1);
                    Instantiate(_bullets[bulletRange], this.transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            Debug.LogError("弾を設定してください");
        }
    }
}
