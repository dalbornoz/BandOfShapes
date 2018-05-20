using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerFinish : MonoBehaviour {

	public BoxCollider collider;

	public List<GameObject> playersInFinish;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playersInFinish.Count > 0)
		{
			Debug.Log ("There are " + playersInFinish.Count + " players in the finish zone!");
		}
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			playersInFinish.Add (other.gameObject);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			if (playersInFinish.Contains (other.gameObject))
			{
				playersInFinish.Remove (other.gameObject);
			}
		}
	}
}
