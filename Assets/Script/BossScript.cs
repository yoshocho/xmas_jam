using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    [SerializeField, Tooltip("敵のライフ")] int _enemyLife = 1;
    [SerializeField, Tooltip("倒すと追加されるスコア")] int _score = 100;
    [SerializeField, Tooltip("エフェクトのプレハブ")] GameObject _effectPrefab;
    [SerializeField] string _loadScene = " ";
    [SerializeField] GameObject _boss2;
    [SerializeField] float _timeLimit = 3;
    ScoreText _scoreText;
    float _timer;
    bool isOn;
    private void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<ScoreText>();
    }
    private void Update()
    {
        if(isOn)
        {
            _timer += Time.deltaTime;

            if(_timer <= _timeLimit)
            SceneManager.LoadScene(_loadScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.gameObject.GetComponent<IDamage>();
            player.AddDamage(1);
        }

        //もしPlayerの弾だったら
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Debug.Log("Hit");
            //残機を減らす
            _enemyLife -= 1;
            Destroy(collision.gameObject);
            if (_enemyLife <= 0)
            {
                //倒したエフェクトを表示
                if (_effectPrefab)
                {
                    var go = Instantiate(_effectPrefab, this.transform.position, this.transform.rotation);
                    Destroy(go, 3f);
                }
                _scoreText.AddScoreText(_score);
                GameManager.Instance.AddScore(_score);

                //自分を破棄
                Destroy(this.gameObject);
                Instantiate(_boss2, this.transform.position, Quaternion.identity);
            }

        }
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }
}
