using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Test : MonoBehaviour
{
    [SerializeField] PlayerScript _player;

    [SerializeField] GameObject[] _lifeIcons = default;
    private void Start()
    {
        _player._hp
            .Subscribe(playerhp => Test2(playerhp));
    }

    void Test2(int hp)
    {
        if (hp >= 3)
        {
            _player._hp.Value = 3;
            return;
        }
        else if(hp <= 0) 
        {
            Debug.Log("GameOver");
        }

        switch (hp)
        {
            case 0:
                _lifeIcons[0].SetActive(false);
                break;
            case 1:
                _lifeIcons[0].SetActive(true);
                _lifeIcons[1].SetActive(false);
                break;
            case 2:
                _lifeIcons[1].SetActive(true);
                _lifeIcons[2].SetActive(false);
                break;
            case 3:
                _lifeIcons[2].SetActive(true);
                break;
        }
        Debug.Log("PlayerのHP" + hp);
    }
}
