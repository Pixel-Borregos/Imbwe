public class ConditionMoveAgent : ConditionMovement
{
    public override bool IsConditionMet()
    {
        return (agent.remainingDistance <= agent.stoppingDistance);
    }
}
