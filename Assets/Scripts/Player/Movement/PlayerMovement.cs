using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform camPos;
    [SerializeField] Animator animator;
    bool setTrigger = false;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0, 0, 0);
        setTrigger = false;
        MovePlayerHelper(z, 1, ref direction, transform.forward, "walk_front");
        MovePlayerHelper(z, -1, ref direction, -transform.forward, "walk_back");
        MovePlayerHelper(x, 1, ref direction, transform.right, "walk_right");
        MovePlayerHelper(x, -1, ref direction, -transform.right, "walk_left");
        if(direction == Vector3.zero)
            animator.SetTrigger("iddle");
        else
        {
            direction *= Time.deltaTime* speed;
            transform.position += direction;
            camPos.position += direction;
        }
    }

    private void MovePlayerHelper(float variable, int magnitude, ref Vector3 direction, Vector3 modifier, string trigger)
    {
        if (variable == magnitude)
            MovePlayerHelperHelper(ref direction, modifier, trigger);
    }
    private void MovePlayerHelperHelper(ref Vector3 direction, Vector3 modifier, string trigger)
    {
        direction += modifier;
        if (!setTrigger)
        {
            animator.SetTrigger(trigger);
            setTrigger = true;
        }
    }
}