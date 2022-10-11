using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct AgentInformation
{
    [Header("Agent Settings")]
    [Space(10)]
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public float stoppingDistance;
    [SerializeField] public float speed;
    [SerializeField] public bool updateRotation;

    public void SetAgent()
    {
        agent.stoppingDistance = stoppingDistance;
        agent.speed = speed;
        agent.updateRotation = updateRotation;
    }
}
