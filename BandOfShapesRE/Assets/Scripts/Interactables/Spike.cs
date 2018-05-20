using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (Mathf.Abs(Mathf.Abs(other.transform.position.x) - Mathf.Abs(this.transform.position.x)) < 0.1 && Mathf.Abs(Mathf.Abs(other.transform.position.y) - Mathf.Abs(this.transform.position.y)) < 0.1 && Mathf.Abs(Mathf.Abs(other.transform.position.z) - Mathf.Abs(this.transform.position.z)) < 0.1)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
