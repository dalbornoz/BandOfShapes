using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    private NavMeshAgent agent;
    private GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(target != null)
            agent.destination = target.transform.position;
        if (Vector3.Distance(transform.position, agent.destination) <= 1.75f && target != null)
        {
            Destroy(target);
            target = null;
            agent.destination = transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            Debug.Log("Wow");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            target = null;
    }

    
}
