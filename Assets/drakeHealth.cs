using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drakeHealth : MonoBehaviour {
	//Shiv
	public float enemyMaxHealth;
	public GameObject ocean;
	public GameObject trampoline;
	public Transform position;
	public Transform position2;

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
		Instantiate (trampoline, position2.position, Quaternion.identity);
		Instantiate (ocean, position.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
