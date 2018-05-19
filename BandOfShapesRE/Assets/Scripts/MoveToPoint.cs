using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    NavMeshAgent agent;

    [HideInInspector]
    public bool selected = false;
    private Renderer rend;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.gameObject.tag == "Terrain")
                    selected = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && selected)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }

        if (!selected)
        {
            rend.material.color = Color.blue;
        }

        else if (selected)
        {
            rend.material.color = Color.white;
        }
    }

    void OnMouseDown()
    {
        if (!selected)
        {
            selected = true;
        }
        else
        {
            selected = false;
        }
    }

}
