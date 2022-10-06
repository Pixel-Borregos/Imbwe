using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NPCEyes : MonoBehaviour
{
    public bool sawPlayer = false;
    public bool sawInai = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            sawPlayer = true;

        if (other.tag == "Inai")
            sawInai = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            sawPlayer = false;

        if (other.tag == "Inai")
            sawInai = false;
    }


}
