using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform[] _muzzle;
    [SerializeField] GameObject _bullet;

    public IntReactiveProperty _hp = new IntReactiveProperty();
    //[SerializeField]     int _playerHp;
    [SerializeField]public int _shootIntervalFrame;

    [SerializeField]public bool _levelUp;

    [SerializeField]public float _playerSpeed = 10;
    Rigidbody2D _rb2d;


    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetButton("Jump") || Input.GetButton("Fire1"))
            .ThrottleFirstFrame(_shootIntervalFrame)
            .Subscribe(_ => ShotBullet());

        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal") * _playerSpeed;
        float y = Input.GetAxisRaw("Vertical") * _playerSpeed;

        _rb2d.velocity = new Vector2(x, y);
    }

    public void ShotBullet()
    {

        if (!_levelUp)
        {
            Instantiate(_bullet, _muzzle[0].position, _muzzle[0].rotation);
        }
        else if (_levelUp)
        {
            for (int i = 0; i < _muzzle.Length; i++)
            {
                Instantiate(_bullet, _muzzle[i].position, _muzzle[i].rotation);
            }
        }
    }
}
