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

    private bool ischild = false;
    private int delay;
    private int waittime = 0;
    private bool stop = false;
    private MovingPlatform ms;

    private float lastShot = 0;
    private bool shooting;
    private bool targeting;
    private float distance;
    private Vector3 heading;
    private Collider targetCollider;

    public float attackRange;
    public float attackInterval;
    public float projectileLife;
    public GameObject shooterProjectilePrefab;
    public Transform shooterProjectileSpawn;
    public float shooterProjectileSpeed;

    public bool isBox;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
		CreateCircleAroundPoint ();
		lineRenderer.widthMultiplier = 0.25f;
		lineRenderer.enabled = false;
        shooting = false;
        targeting = false;
    }

    void Update()
    {
        if (!selected)
        {
            lineRenderer.enabled = false;
        }

        else
        {
            lineRenderer.enabled = true;
        }

        if (ischild)
        {
            if (ms.stop && waittime == 0)
            {
                agent.enabled = true;
                ischild = false;
                transform.parent = null;
                StartCoroutine(Wait());
                
            }
            return;
        }

        if (isBox){
            string test_str = "distance: " + distance + "attackRange: " + attackRange;
            if (selected)
            {
                if (targeting)
                {
                    heading = targetCollider.transform.position - transform.position;
                    distance = heading.magnitude;
                }
                if (shooting && targeting && targetCollider.tag == "Shootable")
                {
                    agent.destination = agent.transform.position;
                    transform.LookAt(targetCollider.transform.position);
                    Shoot();
                }
                if (!shooting && targeting && targetCollider.tag == "Shootable")
                {
                    if (distance < attackRange && targeting)
                    {
                        shooting = true;
                    }
                    else
                    {
                        shooting = false;
                        agent.destination = new Vector3(Mathf.Cos(targetCollider.transform.rotation.y) * distance + targetCollider.transform.position.x, targetCollider.transform.position.y, Mathf.Sin(targetCollider.transform.rotation.y) * distance + targetCollider.transform.position.z);
                    }
                }
            }
        }



        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                if (hit.collider.gameObject.tag != "Player")
                    selected = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && selected && isBox)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                targetCollider = hit.collider;
                if (targetCollider.tag == "Enemy")
                {
                    targeting = true;
                }
                else
                {
                    targeting = false;
                    shooting = false;
                    agent.destination = hit.point;
                }
       
                //Vector3 direction = heading / distance;
                print(hit.collider.tag);

                if (!shooting)
                {
                    agent.destination = hit.point;
                }
				agent.updateRotation = false;
            }
        }

        else if (Input.GetMouseButtonDown(1) && selected && !isBox)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
                agent.updateRotation = false;

            }
        }

    }

    void Shoot()
    {
        if (Time.time > attackInterval + lastShot)
        {
            GameObject shooterProjectile = (GameObject)Instantiate(shooterProjectilePrefab, shooterProjectileSpawn.position, shooterProjectileSpawn.rotation);

            shooterProjectile.GetComponent<Rigidbody>().velocity = shooterProjectile.transform.forward * shooterProjectileSpeed;

            Destroy(shooterProjectile, projectileLife);

            lastShot = Time.time;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Edge" && agent.enabled == false)
        {
            
        }

        

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Platform")
        {
            ms = other.GetComponent<MovingPlatform>();

            delay = ms.delay+5;
            if (!ischild && ms.stop == true && !stop)
            {
                waittime = ms.delay+1;
                StartCoroutine(DelayPlatform());
                agent.enabled = false;
                ischild = true;
                transform.rotation = other.transform.rotation;
                transform.parent = other.transform;
                transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
                Debug.Log("IM ON");
            }
        }
    }

    IEnumerator Wait()
    {
        stop = true;
        yield return new WaitForSeconds(delay);
        stop = false;
    }

    IEnumerator DelayPlatform()
    {
        yield return new WaitForSeconds(waittime);
        waittime = 0;
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
