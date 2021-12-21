using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUpItem : ItemBase
{ 
    [SerializeField, Tooltip("連射速度の上がり幅")]
    int _extraRate = 5;
    protected override void Excute()
    {
        _playerScript._shootIntervalFrame -= _extraRate;
    }
    protected override void TimeUp()
    {      
        _playerScript._shootIntervalFrame += _extraRate;
        Destroy(this.gameObject);
    }
}
