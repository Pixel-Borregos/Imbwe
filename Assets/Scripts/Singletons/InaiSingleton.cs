using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InaiSingleton : MonoBehaviour
{
    private static InaiSingleton _instance;
    public static InaiSingleton GetInstance()
    {
        if (_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent InaiSingleton");
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of InaiSingleton in the scene ");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
