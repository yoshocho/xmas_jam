using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;


public class MapController : MonoBehaviour
{
    public float m_mapSpeed = 0f;
    [SerializeField] float m_resetPos;
    [SerializeField] float m_appearPos;
    [SerializeField] GameOver m_gameOver;
    // Start is called before the first frame update
    void Start()
    {
        m_gameOver.OnScrollStop
            .Subscribe(_ => StopScroll())
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
