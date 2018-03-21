/* This entire script was written by Michael Lozada */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour {

    public AudioClip newTrack2;

    private AudioManager main2;

    // Use this for initialization
    void Start()
    {
        main2 = FindObjectOfType<AudioManager>();

        if(newTrack2 != null)
        {
            main2.changeMusic(newTrack2);
        }
        
    }


    // Update is called once per frame
    void Update ()
    {
		
	}
}
