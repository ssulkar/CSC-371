using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDestroyer : MonoBehaviour {
	//Shiv
	public float lifeSpan;

	void Awake () {
		Destroy(gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void destroyNow(){
		Destroy (gameObject);
	}
}
