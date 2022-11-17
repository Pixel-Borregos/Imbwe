using UnityEngine;

public class ActionInteract : StateMachineAction
{
    [SerializeField] EventTextInteraction textEvent;
    [SerializeField] Animator animator;
    public override void EnterAction()
    {
        //set iddle animation.
        transform.LookAt(PlayerSingleton.GetInstance().transform);
        PlayerSingleton.GetInstance().GetComponent<PlayerBrain>().talkingTo = transform;
        animator.SetTrigger("idle");
        textEvent.Ocurr();
    }
}
