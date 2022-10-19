using UnityEngine;

public class EventChangeScene : MonoBehaviour
{
    [SerializeField] SceneTransitionInfo transitionInformation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Ocurr();
        }
    }
    
    private void Ocurr()
    {
        WorldManager.GetInstance().HandleSceneChange(transitionInformation);
    }
}
