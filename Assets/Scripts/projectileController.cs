using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

	public float projectileSpeed;

	private Rigidbody2D projectileRb;
	// Use this for initialization
	void Awake () {
		projectileRb = GetComponent<Rigidbody2D> ();
		if (transform.localRotation.z > 0) {
			projectileRb.AddForce (new Vector2 (1, 0.5f) * projectileSpeed, ForceMode2D.Impulse);
		} else {
			projectileRb.AddForce (new Vector2 (-1, 0.5f) * projectileSpeed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
