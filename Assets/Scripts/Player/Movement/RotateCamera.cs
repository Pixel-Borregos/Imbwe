using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] List<EventCameraRotation> rotationEvents;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            /*
            transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
            //player.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
            UpdateRotations();*/
            RotateCameraHelper(new Vector3(0, 1, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            /*
            transform.RotateAround(player.transform.position, new Vector3(0, -1, 0), speed * Time.deltaTime);
            player.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
            UpdateRotations();*/
            RotateCameraHelper(new Vector3(0, -1, 0));
        }
    }

    private void RotateCameraHelper(Vector3 direction)
    {
        transform.RotateAround(player.transform.position, direction, speed * Time.deltaTime);
        UpdateRotations();
    }

    private void UpdateRotations()
    {
        foreach(var rotation in rotationEvents)
        {
            rotation.Ocurr();
        }
    }
}
