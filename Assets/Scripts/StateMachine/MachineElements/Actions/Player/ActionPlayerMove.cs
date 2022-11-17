using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActionPlayerMove : PlayerAction
{
    [Space(10)]
    [Header("Action Settings")]
    [SerializeField] float speed;
    Transform camPos;
    public override void EnterAction()
    {
        base.EnterAction();
        camPos = playerCamera.transform;
        animator.SetTrigger("idle");
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
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
            Vector3 targetPosition = transform.position + transform.forward * speed * Time.deltaTime;
            RaycastHit hit;
            bool raycastHit = Physics.Raycast(
                                transform.position, 
                                transform.forward, 
                                out hit,
                                speed * Time.deltaTime,
                                ~(0 << 9));
            if ( raycastHit )
            {
                if (hit.collider.tag == "Wall")
                    return;
            }
            transform.position += transform.forward * speed * Time.deltaTime;
            camPos.position += transform.forward * speed * Time.deltaTime;
            InaiSingleton.GetInstance().GetComponent<NavMeshAgent>().destination = transform.position;
        }
    }

    private float CalculateAngle(float x, float z)
    {
        Vector3 initialAngle = camPos.rotation.eulerAngles;

        if (z != 0 && x == 0)
            return initialAngle.y + ( 45 * ((z == -1) ? 4 : 0) );

        else if (z == 0 && x != 0)
            return initialAngle.y + ( 45 * ( (x == 1) ? 2 : 6) );

        return (z == -1)
                ? initialAngle.y + (45 * ((x == 1) ? 3 : 5))
                : initialAngle.y + (45 * ((x == 1) ? 1 : 7));
    }

    private void CameraRotation()
    {
        float y = Mathf.Ceil(Input.GetAxis("CameraHorizontal"));
        if (y == 0)
            return;

        camPos.RotateAround(transform.position, new Vector3(0, y, 0), 0.5f);
    }
}
