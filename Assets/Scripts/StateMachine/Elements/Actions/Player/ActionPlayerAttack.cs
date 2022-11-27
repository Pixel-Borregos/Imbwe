using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Sadly this scripts contains logic for the camera rotation while attacking and the player attack.
/// This script contains technical debt, which consists of moving the camera logic to a 
///     camera state machine when possible to keep everything organized.
/// </summary>
public class ActionPlayerAttack : PlayerAction
{
    #region SerializedFields
        [Space(10)]
        [Header("Projectile")]
        [SerializeField] GameObject Arrow;

        [Space(10)]
        [Header("Action Camera Settings")]
        [SerializeField] float cameraEnterSpeed;
        [SerializeField] float cameraExitSpeed;
        [SerializeField] float maxUpRotation;
        [SerializeField] float maxDownRotation;
        [SerializeField] float cameraRotationSpeed;
        [SerializeField] float cameraRotationCooldown;
        [SerializeField] float camScreenThreshold;

        [Space(10)]
        [Header("Action Movement Settings")]
        [SerializeField] float moveSpeed;
    #endregion

    PlayerBrain playerBrain;
    public override void EnterAction()
    {
        base.EnterAction();
        animator.SetTrigger("aim");
        animator.speed = 0;
        playerBrain = GetComponent<PlayerBrain>();
        playerBrain.canAttack = false;


        playerCamera.transform.position = transform.position - transform.forward * 1.4f + new Vector3(0, 1.5f, 0);
        playerCamera.transform.LookAt(gameObject.transform.GetChild(5));
        
        transform.GetChild(4).gameObject.SetActive(true);

        
        StartCoroutine("CameraAimEnter");
        StartCoroutine("RotateCamera");
        StartCoroutine("MovePlayer");
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        animator.speed = 1;
        
    }

    public override void ExitAction()
    {
        base.ExitAction();
        playerBrain.StartCoroutine("Cooldown");
        StopCoroutine("MovePlayer");
        StopCoroutine("RotateCamera");
        StartCoroutine("CameraAimExit");
        
        playerCamera.transform.position = transform.position - transform.forward * 1.4f + new Vector3(0, 1.5f, 0);
        playerCamera.transform.LookAt(transform.GetChild(5));
        transform.GetChild(4).gameObject.SetActive(false);

    }

    private IEnumerator CameraAimEnter()
    {
        while(playerCamera.fieldOfView > 30 && animator.speed == 0)
        {
            playerCamera.fieldOfView -= 5;
            yield return new WaitForSecondsRealtime(cameraEnterSpeed);
        }
    }
    private IEnumerator CameraAimExit()
    {
        
        while (playerCamera.fieldOfView < 100)
        {
            playerCamera.fieldOfView += 5;
            yield return new WaitForSecondsRealtime(cameraExitSpeed);
        }
    }

    private IEnumerator RotateCamera()
    {
        while (animator.speed == 0)
        {
            yield return new WaitForSecondsRealtime(cameraRotationCooldown);

            Vector3 mousePos = Input.mousePosition;
            Quaternion currentRotation = playerCamera.transform.rotation;

            if (mousePos.y > Screen.height / 2 + camScreenThreshold)
            {
                if ((currentRotation.x + cameraRotationSpeed) * 100 > maxDownRotation)
                    playerCamera.transform.Rotate(new Vector3(-cameraRotationSpeed, 0, 0));
            }

            else if (mousePos.y < Screen.height / 2 - camScreenThreshold)
            {
                if ((currentRotation.x + cameraRotationSpeed) * 100 < maxUpRotation)
                    playerCamera.transform.Rotate(new Vector3(cameraRotationSpeed, 0, 0));
            }

            if (mousePos.x < camScreenThreshold)
            {
                playerCamera.transform.RotateAround(transform.position,new Vector3(0, -cameraRotationSpeed, 0),cameraRotationSpeed);
                transform.Rotate(new Vector3(0, -cameraRotationSpeed, 0));
            }

            else if (mousePos.x > Screen.width - camScreenThreshold)
            {
                playerCamera.transform.RotateAround(transform.position, new Vector3(0, cameraRotationSpeed, 0), cameraRotationSpeed);
                transform.Rotate(new Vector3(0, cameraRotationSpeed, 0));
            }
        }
    }

    private IEnumerator MovePlayer()
    {
        Transform camPos = playerCamera.transform;
        while (animator.speed == 0)
        {
            yield return new WaitForSeconds(0);
         
            float x = Mathf.Ceil(Input.GetAxis("Horizontal"));
            float z = Mathf.Ceil(Input.GetAxis("Vertical"));

            if (x == 0 && z == 0)
                continue;
            else
            {
                Vector3 direction = CalculateDirection(x, z);
                Vector3 targetPosition = direction * moveSpeed * Time.deltaTime;
                RaycastHit hit;
                bool raycastHit = Physics.Raycast(
                                    transform.position,
                                    targetPosition,
                                    out hit,
                                    moveSpeed * Time.deltaTime,
                                    ~(0 << 9));
                if (raycastHit && hit.collider.tag == "Wall")
                {
                    continue;
                }
                transform.position += direction * moveSpeed * Time.deltaTime;
                camPos.position += direction * moveSpeed * Time.deltaTime;
                InaiSingleton.GetInstance().GetComponent<NavMeshAgent>().destination = transform.position;
            }
        }
    }

    private Vector3 CalculateDirection(float x, float z)
    {
        Vector3 direction = Vector3.zero;
        direction += (x == 0) ? Vector3.zero :
                     transform.right * x;

        direction += (z == 0) ? Vector3.zero :
                     transform.forward * z;
        return direction;
    }

}
