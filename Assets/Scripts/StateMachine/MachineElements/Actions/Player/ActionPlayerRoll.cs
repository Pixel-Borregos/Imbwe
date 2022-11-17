using UnityEngine;
using UnityEngine.AI;

public class ActionPlayerRoll : PlayerAction
{
    [SerializeField] float speed;

    public override void EnterAction()
    {
        base.EnterAction();

        animator.SetTrigger("roll");
        gameObject.GetComponent<PlayerBrain>().canBeDamaged = false;

    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        RaycastHit hit;
        bool raycastHit = Physics.Raycast(
                            transform.position,
                            transform.forward,
                            out hit,
                            speed * Time.deltaTime,
                            ~(0 << 9));

        if (raycastHit)
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.tag == "Wall")
                return;

        }

        transform.position += transform.forward * speed * Time.deltaTime;
        playerCamera.transform.position += transform.forward * speed * Time.deltaTime;
        InaiSingleton.GetInstance().GetComponent<NavMeshAgent>().destination = transform.position;
    }

    public override void ExitAction()
    {
        base.ExitAction();
        gameObject.GetComponent<PlayerBrain>().canBeDamaged = false;
    }
}
