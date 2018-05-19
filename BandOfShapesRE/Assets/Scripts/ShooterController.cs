using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterController : MonoBehaviour {

    NavMeshAgent agent;

    private bool selected;
    private Renderer rend;
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


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rend = GetComponent<Renderer>();
        shooting = false;
        targeting = false;
    }

    void Update()
    {
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
            if(!shooting && targeting && targetCollider.tag == "Shootable")
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
        if (Input.GetMouseButtonDown(1) && selected)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                targetCollider = hit.collider;
                if (targetCollider.tag == "Shootable")
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
            rend.material.color = Color.blue;
        }
        else
        {
            selected = false;
            rend.material.color = Color.white;
        }
    }
}
