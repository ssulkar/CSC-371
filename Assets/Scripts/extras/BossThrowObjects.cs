//this was written by Carlos Hernandez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThrowObjects : MonoBehaviour {

	public GameObject thrownObj;
	public Transform bossTransform;
	public float minForce;
	public float maxForce;
	public float maxDist;


	// Use this for initialization
	void Start () {
		minForce = 5.0f;
		maxForce = 10.0f;
		maxDist = 10.0f;


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	Vector2 getRandomCoordinate()
	{
		float rand_x = bossTransform.position.x + Random.Range (-maxDist, maxDist);
		float rand_y = bossTransform.position.y + Random.Range (-maxDist, maxDist);

		return new Vector2 (rand_x, rand_y);
	}


	float getRandomForce()
	{
		float rand_force = Random.Range (minForce, maxForce);

		return rand_force;
	}
}
