using System.Collections;
using System.Collections.Generic;
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
