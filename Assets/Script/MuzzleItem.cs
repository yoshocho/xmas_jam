using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleItem : ItemBase
{
    [SerializeField, Tooltip("プレイヤーのPlayerScript")]
    PlayerScript _player = default;

    protected override void Excute()
    {
        _player._levelUp = true;
    }

}
