using UnityEngine;

public class ActionInteract : StateMachineAction
{
    [SerializeField] EventTextInteraction textEvent;
    public override void EnterAction()
    {
        //set iddle animation.
        textEvent.Ocurr();
    }
}
