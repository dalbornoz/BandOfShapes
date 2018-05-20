using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamOverController : MonoBehaviour {

    public Transform gameOverCanvas;
    public GameObject triangle;
    public GameObject square;
    public GameObject circle;
	
	// Update is called once per frame
	void Update () {
		if (!triangle.activeSelf || !square.activeSelf || !circle.activeSelf)
        {
            gameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
