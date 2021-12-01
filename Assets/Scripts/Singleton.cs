using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : GameBehaviour where T : GameBehaviour
{
    public bool dontDestroy;

    private static T instance_;
    public static T instance
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }

    //dont destroy on load
    protected virtual void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


