using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject m_enemy;
    [SerializeField]
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(m_enemy,new Vector3(-1,1),Quaternion.identity);
        EnemyGenerate();
    }
    public void EnemyGenerate()
    {
    }
}
