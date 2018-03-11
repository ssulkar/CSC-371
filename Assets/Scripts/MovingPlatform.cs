using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public float xamp;
	public float yamp;
	private float init;

	// Use this for initialization
	void Start () {

		init = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (transform.right * Mathf.Sin (Time.time - init) * Time.deltaTime * xamp);
		transform.Translate (transform.up * Mathf.Cos (Time.time - init) * Time.deltaTime * yamp);
	}
}
