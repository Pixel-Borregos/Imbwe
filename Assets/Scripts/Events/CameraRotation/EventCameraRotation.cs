using UnityEngine;

public class EventCameraRotation : MonoBehaviour
{
    [SerializeField] Transform camTransform;

    public void OnEnable()
    {
        Ocurr();
    }

    public void Ocurr()
    {
        transform.rotation = camTransform.rotation;
    }
}
