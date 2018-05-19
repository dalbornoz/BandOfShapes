using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    NavMeshAgent agent;

    private bool selected;
    private Renderer rend;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
         rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }

    void OnMouseDown()
    {
        if (!selected)
        {
            selected = true;
            rend.material.color = Color.blue;
        }
        else
        {
            selected = false;
            rend.material.color = Color.white;
        }
    }
}
