using UnityEngine;

public class ActionMoveToObjective : MovingAction
{
    public override void UpdateAction()
    {
        Vector3 objective = brain.currentObjective.position;
        Vector3 targetPosition = new Vector3(objective.x, transform.position.y, objective.z);
        agentInfo.agent.SetDestination(targetPosition);
    }
}
