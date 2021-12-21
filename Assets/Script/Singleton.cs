using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<TOwer> : MonoBehaviour where TOwer : Singleton<TOwer> 
{
    public static TOwer Instance { get; private set; } = null;
    public bool IsAlive => Instance != null;

    private void Awake()
    {
        if (!IsAlive)
        {
            Instance = this as TOwer;
            OnAwake();
            return;
        }
        Destroy(this);
    }

    /// <summary>
    /// 派生先用のAwake関数
    /// </summary>
    protected virtual void OnAwake() { }


    private void OnDestroy()
    {
        if (Instance != null || Instance == this)
        {
            Release();
            Instance = null;
        }
    }
    /// <summary>
    /// 派生先用のOnDestroy関数
    /// </summary>
    protected virtual void Release() { }
}
