using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriangleEntrance : MonoBehaviour {
    public Transform exit;
    // Use this for initialization
    //
    private NavMeshAgent agent;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Green")
        {
            agent = other.gameObject.GetComponent<NavMeshAgent>();
            agent.destination = other.gameObject.transform.position;
            agent.enabled = false;
            other.gameObject.transform.position = exit.position;
            agent.enabled = true;
            agent.destination = other.gameObject.transform.position;
        }
    }
}
