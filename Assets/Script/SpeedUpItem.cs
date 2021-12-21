using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : ItemBase
{
    [SerializeField, Tooltip("プレイヤーのPlayerScript")] 
    PlayerScript _player = default;
    [SerializeField, Tooltip("連射速度の上がり幅")] 
    float _extraSpeed = 5f;
    protected override void Excute()
    {
        _player._playerSpeed += _extraSpeed;
    }
}
