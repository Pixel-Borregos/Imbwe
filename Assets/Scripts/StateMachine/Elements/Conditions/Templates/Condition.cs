using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class Condition:MonoBehaviour
{
    public virtual bool IsConditionMet()
    {
        return false;
    }
}
