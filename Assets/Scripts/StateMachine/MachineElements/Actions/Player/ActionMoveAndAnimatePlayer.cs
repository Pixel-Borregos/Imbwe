using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveAndAnimatePlayer : AnimationAction
{
    [Space(10)]
    [Header("Move Settings")]
    [SerializeField] KeyCode key;
    [SerializeField] float speed = 3f;
    [Space(10)]
    [Header("Animation Settings")]
    [SerializeField] string iddleTrigger;
    [SerializeField] string walkTrigger;

    public override void UpdateAction()
    {
        if (Input.GetKey(key))
        {
            MoveAction();
        }
        else
        {
            animator.SetTrigger(iddleTrigger);
        }
    }

    private void MoveAction()
    {
        animator.SetTrigger(walkTrigger);
    }
}
