using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Icon("Assets/pb")]
public class StateMachine : MonoBehaviour
{
    [Header("Machine Settings")]
    [Tooltip("The rate in which the states are read, the lower the number the faster it is.")]
    [SerializeField] public float updateRate;
    [Tooltip("List of states for this machine")]
    [SerializeField] List<StateInformation> states;

    StateInformation currentState;

    private IEnumerator ProcessState()
    {
        currentState.action.EnterAction();
        while (true)
        {
            yield return new WaitForSecondsRealtime(updateRate);

            if (currentState.condition.IsConditionMet())
            {
                Debug.Log("HI");
                currentState.action.UpdateAction();
            }

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
        currentState = states[0];
        StartCoroutine(ProcessState());
    }
}
