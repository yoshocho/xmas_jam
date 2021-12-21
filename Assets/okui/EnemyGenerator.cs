using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject m_enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyGenerate();
    }
    public void EnemyGenerate()
    {
        Instantiate(m_enemy.gameObject);
    }
}
