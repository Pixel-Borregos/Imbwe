using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FriendlyNPCWanderState : FriendlyNPCState
{
    static float WANDER_DISTANCE = 0f;
    static float WANDER_RADIUS = 35f;
    static float WANDER_RATE = 1f;
    private Vector3 WANDER_TARGET = Vector3.zero;


    public FriendlyNPCWanderState(GameObject go)
        :base(go)
    {
        return;
        
    }
    
    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();

        
        Wander();
        
    }

    private void Wander()
    {
        float random_binomialX = Random.Range(-1f, 1f);
        float random_binomialZ = Random.Range(-1f, 1f);

        WANDER_TARGET += new Vector3(random_binomialX * WANDER_RATE, 0, random_binomialZ * WANDER_RATE);
        WANDER_TARGET.Normalize();
        WANDER_TARGET *= WANDER_RADIUS;

        Vector3 targetLocal = WANDER_TARGET + new Vector3(0, 0, WANDER_DISTANCE);
        Vector3 targetWorld = gameObject.transform.InverseTransformVector(targetLocal);

        Test a = gameObject.GetComponent<Test>();
        a.agent.SetDestination(targetWorld);
    }
}
