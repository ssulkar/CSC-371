using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontal : MonoBehaviour {

	public float min=2f;
	public float max=2f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
		min=transform.position.x-6.0f;
		max=transform.position.x+6.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position =new Vector2(Mathf.PingPong(Time.time*5,max-min)+min, transform.position.y);
	}
}
