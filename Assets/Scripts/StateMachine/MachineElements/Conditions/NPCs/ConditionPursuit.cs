public class ConditionPursuit : ConditionMovement
{
    public override bool IsConditionMet()
    {
        return brain.currentObjective.position != agent.destination;
    }
}
