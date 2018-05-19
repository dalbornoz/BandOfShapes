using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPoint : MonoBehaviour
{
    NavMeshAgent agent;
	public LineRenderer lineRenderer;

    [HideInInspector]
    public bool selected = false;
    private Renderer rend;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
		CreateCircleAroundPoint ();
		lineRenderer.widthMultiplier = 0.25f;
		lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
				if (hit.collider.gameObject.tag == "Terrain")
				{
					selected = false;
				}
            }
        }
        if (Input.GetMouseButtonDown(1) && selected)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
				agent.updateRotation = false;
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
			lineRenderer.enabled = true;
        }
        else
        {
            selected = false;
			lineRenderer.enabled = false;
        }
    }

	void CreateCircleAroundPoint ()
	{
		float x;
		float y = 0.0f;
		float z;

		float xradius = 1.0f;
		float zradius = 1.0f;

		float angle = 0.0f;

		int segments = 36;

		lineRenderer.SetVertexCount (segments + 1);
		lineRenderer.useWorldSpace = false;

		for (int i = 0; i < segments + 1; i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * angle) * zradius;

			lineRenderer.SetPosition (i, new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}

}
