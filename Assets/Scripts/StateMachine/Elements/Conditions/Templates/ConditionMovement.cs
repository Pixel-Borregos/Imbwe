using UnityEngine;
using UnityEngine.AI;

public class ConditionMovement : Condition
{
    [SerializeField] public NPCBrain brain;
    [SerializeField] public NavMeshAgent agent;

    private void Reset()
    {
        brain = GetComponent<NPCBrain>();
        agent = GetComponent<NavMeshAgent>();
    }
}
