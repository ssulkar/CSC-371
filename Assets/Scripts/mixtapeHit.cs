using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixtapeHit : MonoBehaviour {
	//Shiv
	public float damage;
	public GameObject explosionParticle;

	private projectileController proCtrl;
	private projectileDestroyer proDstry;


	void Awake () {
		//get parent controller
		proCtrl = GetComponentInParent<projectileController> ();
		proDstry = GetComponentInParent<projectileDestroyer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		//when it collides with the touchable layer it does the following
		if (other.gameObject.layer == LayerMask.NameToLayer ("Touchable")) {
			proCtrl.stopProjectile ();//stops the projectile in place
			Instantiate (explosionParticle, transform.position, transform.rotation);
			Destroy (gameObject); //destroys the actual disc
			proDstry.destroyNow (); //destroys the entire projectile object including particles

			if (other.tag == "Enemy") {
				enemyHealth health = other.gameObject.GetComponent<enemyHealth> ();
				health.addDamage (damage);
			}
			else if (other.tag == "Drake") {
				drakeHealth health = other.gameObject.GetComponent<drakeHealth> ();
				health.addDamage (damage);
			}
		}
	}

	//just a safe guard in case the previous method doesn't work
	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Touchable")) {
			proCtrl.stopProjectile ();
			Instantiate (explosionParticle, transform.position, transform.rotation);
			Destroy (gameObject);

			proDstry.destroyNow ();

			if (other.tag == "Enemy") {
				enemyHealth health = other.gameObject.GetComponent<enemyHealth> ();
				health.addDamage (damage);
			}
		}
	}
}
