using UnityEngine;
using UnityEngine.AI;

public class TriggerEnterInaiAttack : Trigger
{
    [SerializeField] NavMeshAgent agent;
    public override bool IsTriggerActive()
    {
        return PlayerSingleton.GetInstance().
                    GetComponent<PlayerBrain>().isFighting && 
               (agent.remainingDistance <= agent.stoppingDistance);
    }
}
