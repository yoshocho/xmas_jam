using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : MonoBehaviour
{
    public event Action<bool> _onPauseResume;
    public Action<bool> OnPauseResume
    {
        get { return _onPauseResume; }
        set { _onPauseResume = value; }
    }
    public void PauseResume(bool isActive)
    {
        _onPauseResume(isActive); 
    }
}
