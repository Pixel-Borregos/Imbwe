using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class ActionWander : Action
{
    [Header("Wander Settings")]
    [SerializeField] float WANDER_DISTANCE = 0f;
    [SerializeField] float WANDER_RADIUS = 35f;
    [SerializeField] float WANDER_RATE = 1f;
    private Vector3 WANDER_TARGET = Vector3.zero;
    [Header("Wander Setup")]
    [SerializeField] NavMeshAgent agent;

    public override void EnterAction()
    {
        base.EnterAction();
        //set animation?
        agent.isStopped = false;
    }
    public override void UpdateAction()
    {
        float random_binomialX = Random.Range(-1f, 1f);
        float random_binomialZ = Random.Range(-1f, 1f);

        WANDER_TARGET += new Vector3(random_binomialX * WANDER_RATE, 0, random_binomialZ * WANDER_RATE);
        WANDER_TARGET.Normalize();
        WANDER_TARGET *= WANDER_RADIUS;

        Vector3 targetLocal = WANDER_TARGET + new Vector3(0, 0, WANDER_DISTANCE);
        Vector3 targetWorld = gameObject.transform.InverseTransformVector(targetLocal);
        agent.SetDestination(targetWorld);
    }

    public override void ExitAction()
    {
        base.ExitAction();
        agent.isStopped = true;
    }
}
