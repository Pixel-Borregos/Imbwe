using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform camPos;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0, 0, 0);
        if (z == 1)
        {
            direction += transform.forward;
        }
        else if (z == -1)
        {
            direction += -transform.forward;
        }

        if (x == 1)
        {
            direction += transform.right;
        }
        else if (x == -1)
        {
            direction += -transform.right;
        }

        transform.position += direction * speed * Time.deltaTime;
        camPos.position += direction * speed * Time.deltaTime;
    }
}