using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : ItemBase
{
    [SerializeField, Tooltip("連射速度の上がり幅")] 
    float _extraSpeed = 5f;
    protected override void Excute()
    {
        _playerScript._playerSpeed += _extraSpeed;
    }
    protected override void TimeUp()
    {
        _playerScript._playerSpeed -= _extraSpeed;
        Destroy(this.gameObject);
    }
}
