using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoved : MonoBehaviour
{

    public PressureButton trigger;

    //Sets the amount the object moves when trigger is triggered
    Vector3 TriggeredPosition;
    public float xTriggeredMovement = 0;
    public float yTriggeredMovement = 3.0f;
    public float zTriggeredMovement = 0;
    public float speed = 0.5f;

    private Vector3 initialPosition;
    public Vector3 target;


    // Use this for initialization
    void Start()
    {
        initialPosition = this.transform.position;
        TriggeredPosition = new Vector3(initialPosition.x + xTriggeredMovement, initialPosition.y + yTriggeredMovement, initialPosition.z + zTriggeredMovement);
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.isTriggered == true)
        {
            target = TriggeredPosition;
        }
        else
        {
            target = initialPosition;
        }

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}