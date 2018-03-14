using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;
	public GameObject money;

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
		Instantiate (money, transform.position, transform.rotation);
		Destroy (gameObject);
	}

	public float getCurrentHealth(){
		return currentHealth;
	}
}
