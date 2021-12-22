using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : FadeSceneManager
{
    [SerializeField] string sceneName;
    [SerializeField] FadeSceneManager _fade;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { _fade.FadeScene(sceneName, 1.5f); }
    }
}
