//this was written by Carlos Hernandez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBossChase : MonoBehaviour {

	private Rigidbody2D moveBody;
	private Rigidbody2D playerBody;
	public float speed;
	private GameObject player;
	public float updatedSpeed;
	private float dist;
	public float max_speed;


	// Use this for initialization
	void Start () {
		moveBody = GetComponent<Rigidbody2D>();
		player	= GameObject.FindGameObjectWithTag ("Player");
		speed = 1;
		updatedSpeed = speed;
		max_speed = 8;
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

		//Debug.Log ("The distance is: " + dist);

		if (dist > 15)
			updatedSpeed = (max_speed *(dist - 13)/dist )* speed;
		else
			updatedSpeed = 1 * speed;

		if (transform.position.x >= 178)
			moveBody.velocity = new Vector2 (0, 0);
		else
			moveBody.velocity = new Vector2 (updatedSpeed, 0);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			//Vector2 direction = new Vector2 (0,5);
			//Vector2 direction = new Vector2 (50,0);
			//other.gameObject.GetComponent<Rigidbody2D> ().AddForce(direction * pushForce, ForceMode2D.Impulse);

			//pushForce *= 1.5f;
			//if (pushForce > max_force)
			//	pushForce = max_force;

			gameObject.GetComponent<PauseMenu>().Restart();
		}


	}


}
