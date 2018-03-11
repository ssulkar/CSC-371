using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpParticle : MonoBehaviour {

	public string inputButton;
	public ParticleSystem particleEffect;


	// Use this for initialization
	void Start () {
		particleEffect.Stop ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown (inputButton)) {

			particleEffect.Play ();

		}
		
	}
}



// possible particles for items gold teeth = shield/more hp, shoes = higher jump, other?