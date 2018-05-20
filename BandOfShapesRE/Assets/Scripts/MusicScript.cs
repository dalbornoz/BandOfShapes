using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    public AudioSource musicSource;
    public AudioClip musicClip;

	// Use this for initialization
	void Start () {
        musicSource.clip = musicClip;
        musicSource.Play();
	}
	

}
