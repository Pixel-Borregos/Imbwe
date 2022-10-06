using UnityEngine;

public class ActionInteract : Action
{
    [SerializeField] EventTextInteraction textEvent;
    public override void EnterAction()
    {
        //set iddle animation.
        textEvent.Ocurr();
    }
}
