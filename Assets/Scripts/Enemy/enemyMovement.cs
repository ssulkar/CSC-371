using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
	//Shiv
	public float min=2f;
	public float max=2f;

	private Rigidbody2D rb2d;
	private bool facingRight;
	private Animator enemyAnim; 
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.freezeRotation = true;
		min=transform.position.x-6.0f;
		max=transform.position.x+6.0f;
		facingRight = true;
		enemyAnim = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position =new Vector2(Mathf.PingPong(Time.time*5,max-min)+min, transform.position.y);

		float currentSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		enemyAnim.SetFloat ("speed", 2.0f);

		HandleAnimations ();
    }

	void HandleAnimations(){
		//float moveX = Input.GetAxis( "Horizontal");
		float x = rb2d.position.x;
		//ANIMATIONS

		//PLAYER DIRECTION
		if (x >= max-0.5f && facingRight == true) {
			FlipEnemy ();
		} else if (x <= min+0.5f && facingRight == false) {
			FlipEnemy ();
		}
	}

	void FlipEnemy()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
    

    void OnCollisionEnter2D(Collision2D c)
    {
        Vector2 dir = gameObject.GetComponent<Rigidbody2D>().velocity;
        dir.x = dir.x * -1;
        gameObject.GetComponent<Rigidbody2D>().velocity = dir;
    }
}