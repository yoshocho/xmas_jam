using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaelItem : ItemBase
{
    [SerializeField] int _haelPoint = 1;
    protected override void Excute()
    {
        //Debug.Log("回復");
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        player._hp.Value += _haelPoint;
        //Debug.Log(player._hp);
    }
}
