using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private float y;
	private float z;

	void Start ()
	{
		z = transform.position.z;
		y = transform.position.y;
		//offset = transform.position.x - player.transform.position.x;
	}

	void LateUpdate ()
	{
		transform.position = new Vector3 (player.transform.position.x, y, z); 

	}
}
