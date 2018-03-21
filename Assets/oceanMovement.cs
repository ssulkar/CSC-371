using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oceanMovement : MonoBehaviour {
	//Shiv
	public float speed;
	public Transform destination;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, destination.position, speed);
	}
}
