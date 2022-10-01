using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerInteract : Trigger
{
    [SerializeField] Transform player;

    public bool canStartInteraction = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
            canStartInteraction = Input.GetKey(KeyCode.P);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canStartInteraction = false;
        
    }

    public override bool IsTriggerActive()
    {
        
        return canStartInteraction;
    }


}
