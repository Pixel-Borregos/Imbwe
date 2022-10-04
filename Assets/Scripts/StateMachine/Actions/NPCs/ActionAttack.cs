using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : Action
{
    [SerializeField] NPCBrain brain;
    [SerializeField] Animator animator;
    [SerializeField] int damage;
    public bool canAttack;
    public override void EnterAction()
    {
        base.EnterAction();
        //set animation?
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        //set animation
        canAttack = false;
        StartCoroutine(Attack());
    }

    public override void ExitAction()
    {
        base.ExitAction();
        StopCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            yield return new WaitForSecondsRealtime(0);
        canAttack = true;
        brain.DamageObjective(damage);
    }
}
