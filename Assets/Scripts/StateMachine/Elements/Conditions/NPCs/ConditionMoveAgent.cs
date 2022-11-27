using UnityEngine;

public class ConditionMoveAgent : ConditionMovement
{
    [SerializeField] Animator animator;
    public override bool IsConditionMet()
    {
        
        bool reachedDestination = (agent.remainingDistance <= agent.stoppingDistance);
        if (reachedDestination && !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            animator.SetTrigger("idle");

        return !reachedDestination;
    }
}
