using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance() {  return _instance; }

    protected virtual void Awake()
    {
        if( _instance == null)
        {
            _instance = this as T;
        }else
        {
            Destroy( gameObject );
        }
    }
}
