using System.Collections.Generic;

[System.Serializable]
public struct StateInformation
{
    public Action action;

    public Condition condition;

    public List<StateConnectionInformation> connectionInformation;

}