using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform camPos;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CameraRotation(); 
    }

    private void MovePlayer()
    {
        float x = Mathf.Ceil(Input.GetAxis("Horizontal"));
        float z = Mathf.Ceil(Input.GetAxis("Vertical"));


        if (x == 0 && z == 0)
            animator.SetTrigger("idle");
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                animator.SetTrigger("walk");

            transform.rotation = Quaternion.Euler(transform.rotation.x, CalculateAngle(x, z), transform.rotation.z);
            transform.position += transform.forward * speed * Time.deltaTime;
            camPos.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private float CalculateAngle(float x, float z)
    {
        Vector3 initialAngle = camPos.rotation.eulerAngles;
        float angleModifier = 0;

        if (z != 0 && x == 0)
            angleModifier = 45 * ((z == -1) ? 4 : 0);

        else if (z == 0 && x != 0)
            angleModifier = 45 * ((x == 1) ? 2 : 6);

        else
            if (z == -1)
                angleModifier = 45 * ((x == 1) ? 3 : 5);
            else
                angleModifier = 45 * ((x == 1) ? 1 : 7);

        return initialAngle.y + angleModifier;
    }

    private void CameraRotation()
    {
        float y = Mathf.Ceil(Input.GetAxis("CameraHorizontal"));
        float x = Mathf.Ceil(Input.GetAxis("CameraVertical"));
        if (x == 0 && y == 0)
            return;

        camPos.RotateAround(transform.position, new Vector3(x, y,0), 0.5f);
    }
}