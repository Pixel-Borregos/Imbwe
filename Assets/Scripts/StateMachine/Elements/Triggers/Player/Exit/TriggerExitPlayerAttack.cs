using UnityEngine;

public class TriggerExitPlayerAttack : Trigger
{
    [SerializeField] Animator animator;
    [SerializeField] Camera playerCam;
    public override bool IsTriggerActive()
    {
        AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float NTime = animStateInfo.normalizedTime;
        return NTime > 0.73f;
    }

}
