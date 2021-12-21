using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleItem : ItemBase
{

    protected override void Excute()
    {
        _playerScript._levelUp = true;
    }
    protected override void TimeUp()
    {
        _playerScript._levelUp = false;
        Destroy(this.gameObject);
    }

}
