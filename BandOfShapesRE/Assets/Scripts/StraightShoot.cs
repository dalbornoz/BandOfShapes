using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShoot : MonoBehaviour {
    public Transform projectileSpawn;
    public float projectileLife;
    public float attackInterval;
    public GameObject projectilePrefab;
    public float projectileSpeed;

    private float lastShot;
	// Use this for initialization
	void Start () {
        lastShot = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
	}
    void Shoot()
    {
        if (Time.time > attackInterval + lastShot)
        {
            GameObject projectile = (GameObject)Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);

            projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileSpeed;

            Destroy(projectile, projectileLife);

            lastShot = Time.time;
        }
    }
}
