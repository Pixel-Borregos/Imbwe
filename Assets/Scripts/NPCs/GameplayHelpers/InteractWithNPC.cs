using UnityEngine;

public class InteractWithNPC : MonoBehaviour
{
    public bool canStartInteraction = false;

    private void OnTriggerStay(Collider other)
    {

        canStartInteraction = Input.GetKey(KeyCode.P);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canStartInteraction = false; 
        }
    }
}
