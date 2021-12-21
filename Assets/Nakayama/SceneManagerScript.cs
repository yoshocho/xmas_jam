using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] string _name;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
