using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] float m_mapSpeed;
    [SerializeField] float m_resetPos;
    [SerializeField] float m_appearPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * m_mapSpeed);

        if (transform.position.y <= m_resetPos) transform.position = new Vector2(0,m_appearPos);
    }
}
