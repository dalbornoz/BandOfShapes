using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private bool dirFor = true;
    public float speed = 0.2f;
    public float amplitude = 4.0f;
    public int delay = 2;

    private Vector3 rel;
    [HideInInspector]
    public bool stop = false;
    private void Start()
    {
        rel = transform.position;
    }

    void FixedUpdate()
    {
        if (stop)
        {
            return;
        }
        if (dirFor)
            transform.Translate(transform.forward * speed * Time.deltaTime);

        else
            transform.Translate(-transform.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, rel) > amplitude && dirFor)
        {
            StartCoroutine(Wait());
            dirFor = false;
        }

        else if (Vector3.Distance(transform.position, rel) <= 0.1 && !dirFor)
        {
            StartCoroutine(Wait());
            dirFor = true;
        }
    }

    IEnumerator Wait()
    {
        stop = true;
        yield return new WaitForSeconds(delay);
        stop = false;
    }
}
