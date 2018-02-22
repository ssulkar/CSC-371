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
	public float pushForce;


	// Use this for initialization
	void Start () {
		moveBody = GetComponent<Rigidbody2D>();
		player	= GameObject.FindGameObjectWithTag ("Player");
		speed = 1;
		updatedSpeed = speed;
		pushForce = 1;
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

		Debug.Log ("The distance is: " + dist);

		if (dist > 15)
			updatedSpeed = (10 *(dist - 13)/dist )* speed;
		else
			updatedSpeed = 1 * speed;

		moveBody.velocity = new Vector2 (updatedSpeed, 0);
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			Vector2 direction = new Vector2 (0,6);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce(direction * pushForce, ForceMode2D.Impulse);

			pushForce *= 2;
		}


	}


}
