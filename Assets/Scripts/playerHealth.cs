using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

	public float playerMaxHealth;
	private float currentHealth;

	private player_movement playerMov;

	void Start (){
		currentHealth = playerMaxHealth;
		playerMov = GetComponent<player_movement> ();
	}

	void Update() {
		if (transform.position.y < -7) {
			playerDeath ();
		}
	}

	public void addDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			playerDeath ();
		}
	}

	void playerDeath () {
		SceneManager.LoadScene("Level1");
	}
}
