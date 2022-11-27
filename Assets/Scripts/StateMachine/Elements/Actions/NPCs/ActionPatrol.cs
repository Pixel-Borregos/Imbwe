using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : MovingAction
{
    [Header("Patrolling Configuration")]
    [SerializeField] List<Transform> waypoints;
    [SerializeField] bool backwardPatrol = true;

    private Transform current_waypoint;
    private int waypointIndex = 0;
    private short modifier = 1;

    public override void EnterAction()
    {
        base.EnterAction();
        modifier = 1;
        waypointIndex = 0;
        current_waypoint = waypoints[0];
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        Vector3 destination = new Vector3(current_waypoint.position.x, transform.position.y, current_waypoint.position.z);

        agentInfo.agent.SetDestination(destination);

        if (backwardPatrol)
        {
            if (modifier == 1 && waypointIndex + 1 >= waypoints.Count)
                modifier = -1;

            else if (modifier == -1 && waypointIndex - 1 == -1)
                modifier = 1;
        }
        else
        {
            if (waypointIndex + 1 >= waypoints.Count)
                waypointIndex = -1;
        }

        waypointIndex += modifier;
        current_waypoint = waypoints[waypointIndex];
    }
}
