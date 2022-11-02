using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBreath : MonoBehaviour
{
    [SerializeField] int breaths = 50;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(Breath());
    }

    private IEnumerator Breath()
    {
        while (true)
        {

            for (int i = 0; i < breaths; i++)
            {
                light.intensity -= 1f;
                yield return new WaitForSecondsRealtime(0.03f);
            }

            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < breaths; i++)
            {
                light.intensity += 1f;
                yield return new WaitForSecondsRealtime(0.03f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
