using UnityEngine;

public class Action: MonoBehaviour
{
    [Header("Machine configuration")]
    [SerializeField] StateMachine targetMachine;
    [SerializeField] bool updateMachine = false;
    [SerializeField] float updateRate;

    public virtual void Reset()
    {
        targetMachine = gameObject.GetComponent<StateMachine>(); 
    }

    public virtual void EnterAction()
    {
        if (updateMachine)
            targetMachine.updateRate = updateRate;

        return;
    }
    public virtual void UpdateAction()
    {
        return;
    }

    public virtual void ExitAction()
    {
        return;
    }
}
