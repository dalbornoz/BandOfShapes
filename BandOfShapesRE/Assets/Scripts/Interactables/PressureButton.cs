using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour {

    public bool isTriggered;

	// Use this for initialization
	void Start () {
		isTriggered = false;
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
