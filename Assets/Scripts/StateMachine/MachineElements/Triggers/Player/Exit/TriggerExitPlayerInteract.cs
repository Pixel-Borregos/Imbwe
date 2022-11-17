public class TriggerExitPlayerInteract : Trigger
{
    public override bool IsTriggerActive()
    {
        return TextEventManagerSingleton.GetInstance().canStartEvent;
    }
}
