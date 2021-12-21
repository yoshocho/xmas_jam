using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 左右に波を描きながら下にオブジェクトを移動させる
/// </summary>
public class EnemyMoveToWave : MonoBehaviour
{
    /// <summary>波の振り幅</summary>
    [SerializeField] float _amplitude = 1.5f;
    /// <summary>波打つ速さ</summary>
    [SerializeField] float _speedX = 3f;
    /// <summary>下に移動する速さ</summary>
    [SerializeField] float _speedY = 1f;
    /// <summary>オブジェクトが生成された初期位置</summary>
    Vector2 _initialPosition;
    float _timer;

    void Start()
    {
        // 初期位置を記憶しておく
        _initialPosition = this.transform.position;
    }

    void Update()
    {
        // X 座標を三角関数で表現することにより「波打つ・往復する」移動を行う
        _timer += Time.deltaTime;
        float posX = Mathf.Sin(_timer * _speedX) * _amplitude;
        float posY = (-1) * _timer * _speedY; // Y 方向はまっすぐ移動する

        Vector2 pos = _initialPosition + new Vector2(posX, posY);
        transform.position = pos;   // 座標を直接代入することで移動させる
    }
}