using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] string _name;
    [SerializeField] float _waitingTime;
    // Start is called before the first frame update

    private void Start()
    {
        
    }

     IEnumerator ChangeScene(string name)
    {
        yield return new WaitForSeconds(_waitingTime);
        SceneManager.LoadScene(name);
    }

    public void ChangeSceneAsync()
    {
        StartCoroutine(ChangeScene(_name));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
