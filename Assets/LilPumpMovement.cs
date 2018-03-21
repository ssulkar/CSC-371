using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilPumpMovement : MonoBehaviour {

	//Shiv
	private Rigidbody2D rb;
	private bool facingRight;
	// Use this for initialization
	void Start () {
		facingRight = false;
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2(-30f,0f), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (rb.velocity.x < 0 && facingRight == true) {
			flip ();
		} else if (rb.velocity.x > 0 && facingRight == false) {
			flip ();
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Player") {
			pushBack(other);
		}
	}

	void pushBack(Collider2D other){
		Vector2 direction = (gameObject.transform.position - other.transform.position);
		rb.AddForce (direction, ForceMode2D.Impulse);
	}
}
