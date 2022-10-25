using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCameraRotation : MonoBehaviour
{
    Transform camTransform;

    public void Start()
    {
        camTransform = GameObject.Find("Main Camera").transform;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public void OnEnable()
    {
        Ocurr();
    }

    public void Ocurr()
    {
        Quaternion rotation = camTransform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = rotation;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CameraSingleton.GetInstance().
            cameraRotation.rotationEvents.Add(this);
        Ocurr();
    }
}
