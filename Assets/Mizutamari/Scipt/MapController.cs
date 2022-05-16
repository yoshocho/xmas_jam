using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;


public class MapController : MonoBehaviour
{
    public float m_mapSpeed = 0f;
    [SerializeField] float m_resetPos;
    [SerializeField] float m_appearPos;
    [SerializeField] GameOver m_gameOver;
    [SerializeField] Text m_gameOverText;
    [SerializeField] Button m_restartButton;
    [SerializeField] Button m_goTitleButton;
    [SerializeField, Tooltip("ポーズを管理するマネージャー")]
    PauseManager _pauseManager = default;
    bool m_isGameOver = false;
    bool m_isStopScroll;

    // Start is called before the first frame update
    void Start()
    {
        m_gameOverText.text = "";
        m_isGameOver = false;
        m_isStopScroll = false;
        _pauseManager = PauseManager.Instance;
        m_gameOver.OnScrollStop
            .Subscribe(_ => StopScroll())
            .AddTo(this);
        _pauseManager.OnPauseResume += SelfEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_isStopScroll)
        MapScroll();
    }
    public void MapScroll()
    {
        transform.position -= new Vector3(0, Time.deltaTime * m_mapSpeed);

        if (transform.position.y <= m_resetPos) transform.position = new Vector2(0, m_appearPos);
    }
    public void StopScroll()
    {
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        while (m_mapSpeed >= 0)
        {
            m_mapSpeed -= Time.deltaTime;
            yield return null;
        }
        m_isGameOver = true;
        GameOver();

    }
    public void GameOver()
    {
        if(m_isGameOver == true && m_gameOverText && m_restartButton && m_goTitleButton)
        {
            m_gameOverText.text = "Game Over";
            m_restartButton?.gameObject.SetActive(true);
            m_goTitleButton?.gameObject.SetActive(true);
        }
    }
    public void MapStop()
    {
        m_isStopScroll = true;
    }
    void SelfEnabled(bool isactive)
    {
        this.enabled = isactive;
    }
}
