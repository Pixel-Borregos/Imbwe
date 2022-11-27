public class TriggerEnterPlayerInteract : Trigger
{
    public override bool IsTriggerActive()
    {
        return !TextEventManagerSingleton.GetInstance().canStartEvent;
    }
}
