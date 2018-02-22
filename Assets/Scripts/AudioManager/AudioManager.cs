using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource music1;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeMusic(AudioClip music2)
    {
        //if same music clip do not restart
        if (music1.clip.name == music2.name)
        {
            return;
        }

        music1.Stop();
        music1.clip = music2;
        music1.Play();
    }
}
