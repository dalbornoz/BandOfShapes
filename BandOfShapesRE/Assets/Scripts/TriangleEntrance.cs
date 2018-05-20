using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriangleEntrance : MonoBehaviour {
    public Transform exit;
    // Use this for initialization
    //
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Triangle"))
        {
            other.gameObject.transform.position = exit.position;
            other.gameObject.GetComponent<NavMeshAgent>().destination = other.gameObject.transform.position;
        }
    }
}
