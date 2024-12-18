using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Object
{
    public static T instance{
        get{
            if(_singleton == null)
            {
                _singleton = FindAnyObjectByType<T>();
            }
            return _singleton;
        }
    }

    

    private static T _singleton;


    protected void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
