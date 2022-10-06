using UnityEngine;

public class TriggerHostileNPCMoveToTarget : Trigger
{
    [Header("NPC Organs")]
    [SerializeField] NPCBrain brain;
    [SerializeField] NPCEyes eyes;
    public override bool IsTriggerActive()
    {
        if (eyes.sawPlayer || eyes.sawInai)
        {
            if (eyes.sawPlayer && eyes.sawInai)
                brain.SetObjectiveByName((Random.Range(0, 1f) < 0.24f) ? "Inai" : "Player");

            else if (eyes.sawPlayer)
                brain.SetObjectiveByName("Player");

            else if (eyes.sawInai)
                brain.SetObjectiveByName("Inai");

            return true;

        }
        return brain.beingAttacked;
    }
}
