using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float speed;
    public List<EventCameraRotation> rotationEvents;

    private void Start()
    {
        SceneManager.sceneUnloaded += OnUnloadScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RotateCameraHelper(new Vector3(0, 1, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RotateCameraHelper(new Vector3(0, -1, 0));
        }
    }

    private void RotateCameraHelper(Vector3 direction)
    {
        transform.RotateAround(PlayerSingleton.GetInstance().transform.position, direction, speed * Time.deltaTime);
        UpdateRotations();
    }

    private void UpdateRotations()
    {
        foreach(var rotation in rotationEvents)
        {
            rotation.Ocurr();
        }
    }

    void OnUnloadScene(Scene currentScene)
    {
        rotationEvents = new List<EventCameraRotation>();
    }    
}
