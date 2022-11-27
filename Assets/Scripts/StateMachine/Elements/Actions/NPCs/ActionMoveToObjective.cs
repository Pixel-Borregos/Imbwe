using UnityEngine;

public class ActionMoveToObjective : MovingAction
{
    public override void UpdateAction()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
            animator.SetTrigger("walk");
        Vector3 objective = brain.currentObjective.position;
        Vector3 targetPosition = new Vector3(objective.x, transform.position.y, objective.z);
        agentInfo.agent.SetDestination(targetPosition);
    }
}
