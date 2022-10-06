using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitInaiAttack : Trigger
{
    [Header("Brains")]
    [SerializeField] PlayerBrain playerBrain;
    [SerializeField] NPCBrain npcBrain;

    [Header("NPC Attack Configuration")]
    [SerializeField] float attackRange;

    public override bool IsTriggerActive()
    {
        return  Vector3.Distance(transform.position, npcBrain.currentObjective.position) >= attackRange;
    }
}
