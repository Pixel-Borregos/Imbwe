using UnityEngine;
using UnityEngine.AI;

public class MovingAction : Action
{
    [Header("NPC Organs")]
    [SerializeField] public NPCBrain brain;
    [Header("Agent Configuration")]
    [SerializeField] public AgentInformation agentInfo;

    public override void Reset()
    {
        base.Reset();
        brain = GetComponent<NPCBrain>();
        agentInfo.agent = GetComponent<NavMeshAgent>();
        agentInfo.stoppingDistance = agentInfo.agent.stoppingDistance;
        agentInfo.speed = agentInfo.agent.speed;
    }

    public override void EnterAction()
    {
        base.EnterAction();
        agentInfo.agent.isStopped = false;
        agentInfo.SetAgent();
    }

    public override void ExitAction()
    {
        base.ExitAction();
        agentInfo.agent.isStopped = true;
    }
}
