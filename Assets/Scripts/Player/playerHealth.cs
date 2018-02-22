﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public Image healthBar;

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
		healthBar.fillAmount = (currentHealth / playerMaxHealth);
		if ((currentHealth / playerMaxHealth) > (2.0f / 3)) {
			healthBar.color = Color.green;
		} else if ((currentHealth / playerMaxHealth) > (1.0f / 3)) {
			healthBar.color = Color.yellow;
		} else {
			healthBar.color = Color.red;
		}
		if (currentHealth <= 0) {
			playerDeath ();
		}
	}

	void playerDeath () {
		SceneManager.LoadScene("Level1");
	}
}
