using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PressureButton : MonoBehaviour {

    public bool isTriggered;
    private OffMeshLink oof;

	// Use this for initialization
	void Start () {
        oof = GetComponent<OffMeshLink>();
		isTriggered = false;
	}

    private void Update()
    {
        if (isTriggered)
            oof.activated = true;
        else
            oof.activated = false;
    }

    //Triggers while any player object is on the trigger collider
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
            //print("TRIGGERING");
        }
    }

    //Turn off trigger once the player object leaves the trigger
    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        //print("TRIGGER OFF");
    }
}
