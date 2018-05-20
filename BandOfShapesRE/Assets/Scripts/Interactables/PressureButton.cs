using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PressureButton : MonoBehaviour {

    public bool isTriggered;
    private OffMeshLink oof;
    private GameObject enemy;
    public bool initmesh = false;
    public bool enemyTrigger = false;

	// Use this for initialization
	void Start () {
        oof = GetComponent<OffMeshLink>();
		isTriggered = false;
	}

    private void Update()
    {
        if (enemy != null && !enemy.gameObject.activeSelf)
            isTriggered = false;
        if (isTriggered)
            oof.activated = !initmesh;
        else
            oof.activated = initmesh;
    }

    //Triggers while any player object is on the trigger collider
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
            //print("TRIGGERING");
        }

        else if (other.tag == "Enemy" && enemyTrigger)
        {
            enemy = other.gameObject;
            isTriggered = true;
        }
    }

    //Turn off trigger once the player object leaves the trigger
    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        //print("TRIGGER OFF");
    }
}
