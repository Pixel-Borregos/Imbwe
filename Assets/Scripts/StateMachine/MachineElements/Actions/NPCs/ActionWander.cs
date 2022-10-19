using UnityEngine;

public class ActionWander : MovingAction
{
    [Header("Wander Settings")]
    [SerializeField] float WANDER_DISTANCE = 0f;
    [SerializeField] float WANDER_RADIUS = 35f;
    [SerializeField] float WANDER_RATE = 1f;
    private Vector3 WANDER_TARGET = Vector3.zero;
    private float x0, z0;

    public override void UpdateAction()
    {
        /*
        float random_binomialX = Random.Range(-1f, 1f) * WANDER_RATE;
        float random_binomialZ = Random.Range(-1f, 1f) * WANDER_RATE;
        WANDER_DISTANCE = Random.Range(-WANDER_RATE, WANDER_RATE);
        WANDER_TARGET += new Vector3(random_binomialX, 0, random_binomialZ);
        WANDER_TARGET *= WANDER_RADIUS;
       // WANDER_TARGET.Normalize();
        

        Vector3 targetLocal = WANDER_TARGET + new Vector3(WANDER_DISTANCE, 0, WANDER_DISTANCE);
        Vector3 targetWorld = gameObject.transform.InverseTransformVector(targetLocal);
        agentInfo.agent.SetDestination(targetWorld);
        */
        float x1 = x0 * 360;
        float z1 = z0 * 360;

        float x1Deg = Mathf.Cos(x1);
        float z1Deg = Mathf.Sin(z1);

        Vector3 direction = new Vector3(x1Deg, 0, z1Deg) * WANDER_RADIUS;


        agentInfo.agent.SetDestination(transform.position + direction);

        x0 = x1Deg;
        z0 = z1Deg;
    }
}
