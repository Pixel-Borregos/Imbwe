using UnityEngine;
using UnityEngine.AI;

public class ActionMoveToObjective : Action
{
    [Tooltip("NPC's brain")]
    [SerializeField] NPCBrain brain;
    [SerializeField] NavMeshAgent agent;

    public override void EnterAction()
    {
        base.EnterAction();
        //set animation
        agent.isStopped = false;
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        Vector3 objective = brain.currentObjective.position;
        Vector3 targetPosition = new Vector3(objective.x, transform.position.y, objective.z);
        agent.SetDestination(targetPosition);

    }

    public override void ExitAction()
    {
        base.ExitAction();
        agent.isStopped = true;
    }

}
