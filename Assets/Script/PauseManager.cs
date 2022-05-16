using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseManager : Singleton<PauseManager>
{
    /// <summary>ポーズに必要な関数を格納するAction</summary>
    event Action<bool> _onPauseResume;
    public Action<bool> OnPauseResume
    {
        get { return _onPauseResume; }
        set { _onPauseResume = value; }
    }
    /// <summary>呼ぶとポーズする関数</summary>
    /// <param name="isActive"></param>
    public void PauseResume(bool isActive)
    {
        _onPauseResume(isActive); 
    }
}
