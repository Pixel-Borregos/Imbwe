using UnityEngine;
using UnityEngine.AI;

public class MovingAction : StateMachineAction
{
    [Header("NPC Organs")]
    [SerializeField] public NPCBrain brain;
    [SerializeField] public AgentInformation agentInfo;
    [SerializeField] public Animator animator;

    public override void Reset()
    {
        base.Reset();
        brain = GetComponent<NPCBrain>();
        agentInfo.agent = GetComponent<NavMeshAgent>();
        agentInfo.stoppingDistance = agentInfo.agent.stoppingDistance;
        agentInfo.speed = agentInfo.agent.speed;
        agentInfo.updateRotation = GetComponent<NavMeshAgent>().updateRotation;
        
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
        animator.SetTrigger("idle");
    }
}
