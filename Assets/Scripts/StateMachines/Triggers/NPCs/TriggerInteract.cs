using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : Trigger
{
    [SerializeField] Transform player;
    public override bool IsTriggerActive()
    {
        return Input.GetKeyDown(KeyCode.P) && Vector3.Distance(player.position, transform.position) < 3f;
    }


}
