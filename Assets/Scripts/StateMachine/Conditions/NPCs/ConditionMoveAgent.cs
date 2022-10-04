using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ConditionMoveAgent : Condition
{
    [SerializeField] NavMeshAgent agent;

    public override bool IsConditionMet()
    {
        return (agent.remainingDistance <= agent.stoppingDistance);
    }
}
