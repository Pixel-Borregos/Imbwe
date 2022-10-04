using UnityEngine;
using UnityEngine.AI;

public class TriggerEnterInaiAttack : Trigger
{
    [SerializeField] PlayerBrain playerBrain;
    [SerializeField] NavMeshAgent agent;
    public override bool IsTriggerActive()
    {
        return playerBrain.isFighting && (agent.remainingDistance <= agent.stoppingDistance);
    }
}
