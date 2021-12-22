using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class LifeUI : MonoBehaviour
{
    [SerializeField] PlayerScript _player;

    [SerializeField] GameObject _lifeIcon = default;
    [SerializeField] GameObject _deathIcon = default;
    [SerializeField] GameObject _scorePanel = default;

    private void Start()
    {
        Instantiate(_lifeIcon, _scorePanel.transform);
        Instantiate(_lifeIcon, _scorePanel.transform);
        Instantiate(_lifeIcon, _scorePanel.transform);
        _player._hp
            .Subscribe(playerhp => ApllyHp(playerhp));
    }

    void ApllyHp(int hp)
    {
        if (hp >= 3)
        {
            _player._hp.Value = 3;
            return;
        }
        else if (hp <= 0)
        {
            Debug.Log("GameOver");
        }

        switch (hp)
        {
            case 0:
                DestroyTransform();
                Instantiate(_deathIcon, _scorePanel.transform);
                Instantiate(_deathIcon, _scorePanel.transform);
                Instantiate(_deathIcon, _scorePanel.transform);
                break;
            case 1:
                DestroyTransform();
                Instantiate(_lifeIcon, _scorePanel.transform);
                Instantiate(_deathIcon, _scorePanel.transform);
                Instantiate(_deathIcon, _scorePanel.transform);
                break;
            case 2:
                DestroyTransform();
                Instantiate(_lifeIcon, _scorePanel.transform);
                Instantiate(_lifeIcon, _scorePanel.transform);
                Instantiate(_deathIcon, _scorePanel.transform);
                break;
            case 3:
                DestroyTransform();
                Instantiate(_lifeIcon, _scorePanel.transform);
                Instantiate(_lifeIcon, _scorePanel.transform);
                Instantiate(_lifeIcon, _scorePanel.transform);
                break;
        }
        Debug.Log("PlayerのHP" + hp);
    }
    void DestroyTransform()
    {
        foreach (Transform n in _scorePanel.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}
