//this was written by Carlos Hernandez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAnim : MonoBehaviour {

	public string inputButton;
	public Animator anim;


	// Use this for initialization
	void Start () {
	//	anim.ResetTrigger("Jump");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown (inputButton)) {

			anim.Play (null);

		} else {
			//anim.StopPlayback ();
		}

	}
}
