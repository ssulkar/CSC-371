using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public AudioClip winSound;
    public float volume;
    AudioSource audio;
    public bool alreadyPlayed = false;

    private player_movement player;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        volume = 0.33f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!alreadyPlayed && player.count == 1)
        {
            audio.PlayOneShot(winSound, volume);
            alreadyPlayed = true;
        }
	}
}
