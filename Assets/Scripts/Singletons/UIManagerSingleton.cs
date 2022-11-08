using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerSingleton : MonoBehaviour
{
    [SerializeField] List<GameObject> uiElements;

    private static UIManagerSingleton _instance;
    public static UIManagerSingleton GetInstance()
    {
        if (_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent UIManagerSingleton");
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of UIManagerSingleton in the scene ");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void ChangeGameModeUI(int index)
    {
        for(int i = 0; i < uiElements.Count; i++)
        {
            uiElements[i].gameObject.SetActive(i == index);
        }
    }

}
