using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSingleton : MonoBehaviour
{

    private static LightSingleton _instance;
    public static LightSingleton GetInstance()
    {
        if (_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent LightSingleton");
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of LightSingleton in the scene ");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
