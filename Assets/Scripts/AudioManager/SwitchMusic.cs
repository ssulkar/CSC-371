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
