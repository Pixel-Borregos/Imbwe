using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
            player.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(player.transform.position, new Vector3(0, -1, 0), speed * Time.deltaTime);
            player.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }
}
