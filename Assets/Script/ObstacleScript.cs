using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] string _destroyAreaName = " ";
    [SerializeField] EnemyBulletBase _bullet = default;
    [SerializeField] Transform _instancePos = default;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_destroyAreaName))
        {
            Destroy(this.gameObject);
        }
    }
    public void CreateBullet()
    {
        if (_bullet)
        {
            if (_instancePos)
            {
                Instantiate(_bullet, _instancePos.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_bullet, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            Debug.LogError("弾を設定してください");
        }
    }
}
