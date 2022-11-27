using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitPlayerRoll : Trigger
{
    [SerializeField] Animator animator;
    public override bool IsTriggerActive()
    {
        AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float NTime = animStateInfo.normalizedTime;
        return NTime > 0.6f;
    }
}
