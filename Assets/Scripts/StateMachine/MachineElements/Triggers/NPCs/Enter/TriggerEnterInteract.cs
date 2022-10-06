using UnityEngine;

public class TriggerEnterInteract : Trigger
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
