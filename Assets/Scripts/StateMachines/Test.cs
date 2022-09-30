using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
 
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(Process());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Process()
    {
        while (true) 
        {
            yield return new WaitForSecondsRealtime(0.1f);

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                yield return new WaitForSecondsRealtime(0.5f);
                
            }
        }
    }

}
