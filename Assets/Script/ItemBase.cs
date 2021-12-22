using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField,Tooltip("アイテムの制限時間")] float _limitTime  =20;
    [SerializeField, Tooltip("アイテムの移動先")] Transform _itemPosition;
    /// <summary>プレイヤーのPlayerScript </summary>
    protected PlayerScript _playerScript = default;
    float _timer = 0f;

    private void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>_limitTime)
        {
            TimeUp();
        }
    }
    protected abstract void Excute();
    protected virtual void TimeUp(){}
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Excute();
            //どっか違うとこに移動させる
            this.transform.position = _itemPosition.position;
        }
    }
}
