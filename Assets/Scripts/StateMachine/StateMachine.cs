using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [Header("Machine Settings")]
    [Tooltip("The rate in which the states are read, the lower the number the faster it is.")]
    [SerializeField] float updateRate;
    [Tooltip("List of states for this machine")]
    [SerializeField] List<StateInformation> states;
    [Tooltip("Index of the state that the machine is executing")]
    [SerializeField] int initialState = 0;

    StateInformation currentState;

    private IEnumerator ProcessState()
    {
        currentState.action.EnterAction();
        while (true)
        {
            yield return new WaitForSecondsRealtime(updateRate);

            if (currentState.condition.IsConditionMet())
                currentState.action.UpdateAction();

            foreach(StateConnectionInformation connection in currentState.connectionInformation)
            {
                if (connection.trigger.IsTriggerActive())
                {
                    currentState.action.ExitAction();
                    currentState = states[connection.nextState];
                    currentState.action.EnterAction();
                    break;
                }
            }
        }
    }

    private void OnEnable()
    {
        InitMachine();
    }

    private void OnDisable()
    {
        StopCoroutine(ProcessState());
    }

    private void InitMachine()
    {
        currentState = states[initialState];
        StartCoroutine(ProcessState());
    }
}
