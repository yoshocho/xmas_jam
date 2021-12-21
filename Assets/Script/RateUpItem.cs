using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUpItem : ItemBase
{ 
    [SerializeField,Tooltip("プレイヤーのPlayerScript")]
    PlayerScript _player = default;
    [SerializeField, Tooltip("連射速度の上がり幅")]
    int _extraRate = 5;
    protected override void Excute()
    {
        _player._shootIntervalFrame -= _extraRate;
    }
}
