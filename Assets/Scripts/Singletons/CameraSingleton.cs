using UnityEngine;

public class CameraSingleton : MonoBehaviour
{
    public RotateCamera cameraRotation;

    private static CameraSingleton _instance;
    public static CameraSingleton GetInstance()
    {
        if (_instance == null)
        {
            throw new System.NullReferenceException("You are trying to access a nonexistent CameraSingleton");
        }
        return _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("There is already an instance of CameraSingleton in the scene ");
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraRotation = GetComponent<RotateCamera>();
    }
}
