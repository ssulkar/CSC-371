using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float min=2f;
	public float max=2f;

	private Rigidbody2D rb2d;
	private bool facingRight;
	private Animator enemyAnim; 
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.freezeRotation = true;
		min=transform.position.x;
		max=transform.position.x+12;
		facingRight = true;
		enemyAnim = GetComponent<Animator> ();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position =new Vector2(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y);

		float currentSpeed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		enemyAnim.SetFloat ("speed", Mathf.Abs(currentSpeed));

		HandleAnimations ();
    }

	void HandleAnimations(){
		//float moveX = Input.GetAxis( "Horizontal");
		float moveX = rb2d.velocity.x;
		//ANIMATIONS

		//PLAYER DIRECTION
		if (moveX > 0.0f && facingRight == true) {
			FlipEnemy ();
		} else if (moveX < 0.0f && facingRight == false) {
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