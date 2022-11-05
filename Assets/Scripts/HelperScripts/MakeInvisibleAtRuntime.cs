using UnityEngine;

public class MakeInvisibleAtRuntime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //make object transparent
        GetComponent<MeshRenderer>().enabled = false;
    }

}
