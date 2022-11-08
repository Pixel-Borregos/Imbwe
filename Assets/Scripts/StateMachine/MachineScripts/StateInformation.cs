using System.Collections.Generic;

[System.Serializable]
public struct StateInformation
{
    public StateMachineAction action;

    public Condition condition;

    public List<StateConnectionInformation> connectionInformation;

}