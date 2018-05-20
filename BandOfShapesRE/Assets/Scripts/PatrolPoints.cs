using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolPoints : MonoBehaviour {
    public Transform[] points;
    private int destPoint;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        destPoint = 0;
        agent = GetComponent<NavMeshAgent>();
        GoToNextPatrolPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if(agent.remainingDistance < 1f)
        {
            GoToNextPatrolPoint();
        }
		
	}
    void GoToNextPatrolPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
