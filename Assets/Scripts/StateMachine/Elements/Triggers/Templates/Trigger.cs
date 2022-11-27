using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class Trigger: MonoBehaviour
{
    public virtual bool IsTriggerActive()
    {
        return false;
    }
}
