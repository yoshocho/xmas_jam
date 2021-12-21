using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField,Tooltip("敵のライフ")] int _enemyLife = 1;
    [SerializeField, Tooltip("倒すと追加されるスコア")] int _score = 100;
    [SerializeField, Tooltip("エフェクトのプレハブ")] GameObject _effectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //もしPlayerの弾だったら
        if (collision.tag =="PlayerBullet")
        {
            //残機を減らす
            _enemyLife -= 1;
            Destroy(collision.gameObject);
            if (_enemyLife<=0)
            {
                //倒したエフェクトを表示
                if (_effectPrefab)
                {
                    Instantiate(_effectPrefab, this.transform.position, _effectPrefab.transform.rotation);
                }
                GameManager.Instance.AddScore(_score);
                //自分を破棄
                Destroy(this.gameObject);
            }
            
        }
        if (collision.tag =="End")
        {
            Destroy(this.gameObject);
        }
    }
}
