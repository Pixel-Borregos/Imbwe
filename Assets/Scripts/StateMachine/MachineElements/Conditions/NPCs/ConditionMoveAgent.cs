using UnityEngine;

public class ConditionMoveAgent : ConditionMovement
{
    [SerializeField] Animator animator;
    public override bool IsConditionMet()
    {
        bool canMove = (agent.remainingDistance <= agent.stoppingDistance) && 
                        Random.Range(0f,1f) < 0.04f;
        if (!canMove && (agent.remainingDistance <= agent.stoppingDistance) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            animator.SetTrigger("idle");

        return canMove;
    }
}
