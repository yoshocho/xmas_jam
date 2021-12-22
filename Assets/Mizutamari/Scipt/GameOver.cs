using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UniRx;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] Image m_gameoverImage;
    
    [SerializeField] PlayerScript m_player;

    Subject<Unit> m_scrollStopSubject = new Subject<Unit>();

    public IObservable<Unit> OnScrollStop => m_scrollStopSubject;
    // Start is called before the first frame update
    void Start()
    {
        //_player.OnGameOver
        //    .Subscribe(_ => ScrollStop())
        //    .AddTo(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_scrollStopSubject.OnNext(Unit.Default);
            m_gameoverImage.DOFade(0.8f, 2.3f).SetLink(gameObject);
        }
    }
    public void ScrollStop()
    {
        //m_scrollStopSubject.OnNext(Unit.Default);
        //m_gameoverImage.DOFade(0.8f, 2.3f).SetLink(gameObject);   
    }
}
