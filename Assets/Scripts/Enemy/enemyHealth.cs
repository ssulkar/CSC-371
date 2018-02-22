using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	private float currentHealth;
	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -7) {
			enemyDeath ();
		}
	}

	public void addDamage(float damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			enemyDeath ();
		}
	}

	void enemyDeath () {
		Destroy (gameObject);
	}
}
