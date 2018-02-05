using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    public int health;
    public bool hasDied;
    public GameObject deathParticle;
    public GameObject respawnParticle;

    private player_movement player;

    // Use this for initialization
    void Start () {
        hasDied = false;

        player = FindObjectOfType<player_movement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < -7)
        {
            
            hasDied = true;
        }

        if(hasDied == true)
        {
            Instantiate(deathParticle, player.transform.position, player.transform.rotation);
            SceneManager.LoadScene("Main");
            Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
        }
	}
}
