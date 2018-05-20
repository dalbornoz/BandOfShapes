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
        if (target != null)
        {
            agent.destination = target.transform.position;
        }
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= 1.75f)
        {
            Debug.Log("DIE");
            target.gameObject.SetActive(false);
            target = null;
            agent.destination = transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && target == null)
        {
            target = other.gameObject;
            Debug.Log("Wow");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && target == null)
            target = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            target = null;
    }

    
}
