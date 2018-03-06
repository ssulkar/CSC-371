using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	//
	private float nextActionTime = 0.0f;
	private float period = 5.0f; // 5 seconds

	void Start ()
	{
		nextActionTime = Time.time + period;
	}

	void Update (){

		if (Time.time >= nextActionTime) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{

		if ( other.gameObject.tag == "Player")
		{
			//Destroy (other.gameObject);  if we want to destroy certain things it gets in contact with
			Destroy (gameObject);
		}
			
		return;
	}
}
