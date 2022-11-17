using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPlayerInteract : PlayerAction
{
    public override void EnterAction()
    {
        base.EnterAction();

        transform.LookAt(
            GetComponent<PlayerBrain>().talkingTo
        );

        animator.SetTrigger("idle");
    }
}
