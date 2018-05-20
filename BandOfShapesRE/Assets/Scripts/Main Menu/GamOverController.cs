using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamOverController : MonoBehaviour {

    public Transform canvas;
    public GameObject triangle;
    public GameObject square;
    public GameObject circle;
	
	// Update is called once per frame
	void Update () {
		if (triangle.activeSelf == false || square.activeSelf == false || circle.activeSelf == false)
        {
            Debug.Log("Game Over");
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
