using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct AgentInformation
{

    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public float stoppingDistance;
    [SerializeField] public float speed;

    public void SetAgent()
    {
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
    }
}
