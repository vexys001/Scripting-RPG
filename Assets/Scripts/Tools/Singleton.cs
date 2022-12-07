using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour where T : Component
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] objs = FindObjectsOfType<T>();
                if (objs.Length > 0)
                {
                    T instance = objs[0];
                    _instance = instance;
                    DontDestroyOnLoad(_instance.gameObject);
                }
                else
                {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name;
                    _instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }
            }

            return _instance;
        }
    }
}
