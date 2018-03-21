/* This entire script was written by Michael Lozada */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour {

    public AudioClip newTrack;

    private AudioManager main;
    
    // Use this for initialization
	void Start () {
        main = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // makes sure there is a new track to play, if there is calls AudioManager to make change
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(newTrack != null)
            {
                main.changeMusic(newTrack);
            }
            
        }
    }
}
