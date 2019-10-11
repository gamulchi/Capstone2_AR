using System;
using System.Reflection;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static object s_syncObject = new object();
    private static T s_instance = null;

    public static T _instance
    {
        get
        {
            if (null == s_instance)
            {
                lock (s_syncObject)
                {
                    if (null == s_instance)
                    {
                        s_instance = GameObject.FindObjectOfType(typeof(T)) as T;

                        if (null == s_instance)
                        {
                            s_instance = new GameObject(typeof(T).Name, typeof(T)).GetComponent<T>();
                            DontDestroyOnLoad(s_instance);
                        }
                    }
                }
            }

            return s_instance;
        }
    }
}

