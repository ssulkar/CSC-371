using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	public float projectileSpeed;
	public float upwardForce;
	private Rigidbody2D projectileRb;
	// Use this for initialization

	void Awake () {
		/*projectileRb = GetComponent<Rigidbody2D> ();

		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = (Vector2)(worldMousePos - transform.position);

		direction.Normalize ();

		projectileRb.AddForce (new Vector2 (direction.x, direction.y + 0.5f) * projectileSpeed, ForceMode2D.Impulse);*/
		projectileRb = GetComponent<Rigidbody2D> ();
		if (transform.localRotation.z > 0) {
			projectileRb.AddForce (new Vector2 (-1, upwardForce) * projectileSpeed, ForceMode2D.Impulse);
		} else {
			projectileRb.AddForce (new Vector2 (1, upwardForce) * projectileSpeed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void stopProjectile(){
		projectileRb.velocity = new Vector2(0, 0);
	}
}
