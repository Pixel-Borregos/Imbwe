using UnityEngine;

public class ActionWander : MovingAction
{
    [Header("Wander Settings")]
    [SerializeField] float WANDER_DISTANCE = 0f;
    [SerializeField] float WANDER_RADIUS = 35f;
    [SerializeField] float WANDER_RATE = 1f;
    [Space(10)]

    private float x0, z0;

    public override void EnterAction()
    {
        base.EnterAction();
        x0 = Random.Range(-1f, 1f);
        z0 = Random.Range(-1f, 1f);
    }

    public override void UpdateAction()
    {
        float x1 = x0 * 360;
        float z1 = z0 * 360;

        float x1Deg = Mathf.Cos(x1) * WANDER_RATE;
        float z1Deg = Mathf.Sin(z1) * WANDER_RATE;

        Vector3 direction = new Vector3(x1Deg, 0, z1Deg) * WANDER_RADIUS;
        direction +=  new Vector3(WANDER_DISTANCE,0,WANDER_DISTANCE);

        agentInfo.agent.SetDestination(transform.position + direction);

        x0 = x1Deg;
        z0 = z1Deg;

        animator.SetTrigger("walk");
    }

}
