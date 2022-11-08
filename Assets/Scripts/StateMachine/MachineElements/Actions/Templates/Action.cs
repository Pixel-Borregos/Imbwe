using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class StateMachineAction: MonoBehaviour
{
    [Header("Machine configuration")]
    [SerializeField] StateMachine targetMachine;
    [SerializeField] bool updateMachine = false;
    [SerializeField] float updateRate;

    public virtual void Reset()
    {
        targetMachine = gameObject.GetComponent<StateMachine>();
        if(targetMachine != null)
            updateRate = targetMachine.updateRate; 
        
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
