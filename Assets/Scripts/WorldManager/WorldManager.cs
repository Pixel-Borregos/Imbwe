using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    private static WorldManager _instance;

    public static WorldManager GetInstance()
    {
        if(_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent World Manager");
        }
        return _instance;
    }

    private void Awake()
    {
        if( _instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of World Manager in the scene ");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void HandleSceneChange(SceneTransitionInfo transitionInformation)
    {
        SceneManager.LoadScene(
            transitionInformation.targetScene.ToString()
        );
    }
    
}
