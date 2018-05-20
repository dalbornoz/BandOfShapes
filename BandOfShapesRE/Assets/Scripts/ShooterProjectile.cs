using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjectile : MonoBehaviour {

    public Transform Target;
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Target.position) <= 1.0f)
        {
            Target.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
