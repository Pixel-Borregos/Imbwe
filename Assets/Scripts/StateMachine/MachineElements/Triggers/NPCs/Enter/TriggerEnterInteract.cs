using UnityEngine;

public class TriggerEnterInteract : Trigger
{
    [SerializeField] GameObject interactUI;
    public bool canStartInteraction = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            canStartInteraction = Input.GetKey(KeyCode.E);
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canStartInteraction = false;
            interactUI.SetActive(false);
        }
        
    }

    public override bool IsTriggerActive()
    {
        
        return canStartInteraction;
    }


}
