using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public Image healthBar;

	public float playerMaxHealth;
	private float currentHealth;

	private player_movement playerMov;

	private int cloutlvl;
	private int fol;
	private int money;

	void Start (){
		currentHealth = playerMaxHealth;
		playerMov = GetComponent<player_movement> ();

		cloutlvl = PlayerPrefs.GetInt ("level");
		fol = PlayerPrefs.GetInt ("followers");
		money = PlayerPrefs.GetInt ("money");
	}

	void Update() {
		if (transform.position.y < -7) {
			playerDeath ();
		}
	}

	public void addDamage(float damage){
		currentHealth -= damage;

		//controls how filled the health bar is
		healthBar.fillAmount = (currentHealth / playerMaxHealth);
	
		//if else block controls color of the health bar
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
		PlayerPrefs.SetInt ("level", cloutlvl);
		PlayerPrefs.SetInt ("followers", fol);
		PlayerPrefs.SetInt ("money", money);
		SceneManager.LoadScene("Level1");
	}
}
