using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float min=2f;
	public float max=2f;
	private Rigidbody2D rb2d; 
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.freezeRotation = true;
		min=transform.position.x;
		max=transform.position.x+12;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position =new Vector2(Mathf.PingPong(Time.time*2,max-min)+min, transform.position.y);

    }
    

    void OnCollisionEnter2D(Collision2D c)
    {
        Vector2 dir = gameObject.GetComponent<Rigidbody2D>().velocity;
        dir.x = dir.x * -1;
        gameObject.GetComponent<Rigidbody2D>().velocity = dir;
    }
}