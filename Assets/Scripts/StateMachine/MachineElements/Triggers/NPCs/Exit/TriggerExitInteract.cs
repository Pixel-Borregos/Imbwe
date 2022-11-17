using UnityEngine;

public class TriggerExitInteract : Trigger
{
    [SerializeField] EventTextInteraction textEvent;
    public override bool IsTriggerActive()
    {
        return TextEventManagerSingleton.GetInstance().canStartEvent;
    }
}
