using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] PlayerScript _player;
    [SerializeField] Image m_gameoverImage;
    [SerializeField] Text m_gameOverText;
    [SerializeField] Button m_restartButton;
    [SerializeField] Button m_goTitleButton;


    // Update is called once per frame
    void Update()
    {
        if(_player._hp.Value <= 0)
        {
            m_gameoverImage.DOFade(0.8f, 2.3f).SetLink(gameObject);
            m_gameOverText.gameObject.SetActive(true);
            m_gameOverText.text = "Game Over";
            m_restartButton?.gameObject.SetActive(true);
            m_goTitleButton?.gameObject.SetActive(true);
        }
    }
}
