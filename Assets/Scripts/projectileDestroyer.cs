using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDestroyer : MonoBehaviour {

	public float lifeSpan;
	// Use this for initialization
	void Awake () {
		Destroy(gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
