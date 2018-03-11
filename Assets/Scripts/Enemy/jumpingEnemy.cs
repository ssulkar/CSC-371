using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingEnemy : MonoBehaviour {

	public float jumpHeight;
	public float jumpRate;
	public float coolDown;
	public LayerMask groundLayer;
	public Transform groundCheck;

	private bool isGrounded = false;
	private float groundCheckRadius = 0.2f;
	private Animator vatoAnim;
	// Use this for initialization
	void Start () {
		vatoAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		HandleEnemyJump ();
	}

	void HandleEnemyJump(){
		if (Time.time > coolDown) {
			coolDown = Time.time + jumpRate;
			EnemyJump ();
		}
		vatoAnim.SetFloat ("verticalSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}

	void EnemyJump(){
		if (isGrounded == true) {
			isGrounded = false;
			GetComponent<Rigidbody2D> ().AddForce (transform.up * jumpHeight, ForceMode2D.Impulse);
			vatoAnim.SetBool ("isGrounded", isGrounded);
		}
	}
	void OnTriggerEnter2D (Collider2D other){
		//when it collides with the touchable layer it does the following
		if (other.gameObject.layer == LayerMask.NameToLayer ("Touchable")) {
			isGrounded = true;
			vatoAnim.SetBool ("isGrounded", isGrounded);
		}
	}
}
