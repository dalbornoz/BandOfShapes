using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriangleClassObstacle : MonoBehaviour {
    public Transform exit;
    // Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Triangle"))
        {
            other.gameObject.transform.position = exit.position + new Vector3(1.0f, 0, 1.0f);
        }
    }
}
