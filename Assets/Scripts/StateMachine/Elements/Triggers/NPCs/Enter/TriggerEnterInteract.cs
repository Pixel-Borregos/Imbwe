using UnityEngine;

public class TriggerEnterInteract : Trigger
{
    [SerializeField] GameObject interactUIClue;
    public bool canStartInteraction = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            canStartInteraction = Input.GetKey(KeyCode.E);
            interactUIClue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canStartInteraction = false;
            interactUIClue.SetActive(false);
        }
        
    }

    public override bool IsTriggerActive()
    {
        return canStartInteraction;
    }


}
