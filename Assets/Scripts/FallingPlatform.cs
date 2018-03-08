using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float fallDelay;

	private Vector2 originPosition;
	private Quaternion originRotation;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		originPosition = transform.position;
		originRotation = transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.collider.CompareTag("Player")){
			StartCoroutine (Fall ());
			
		}

	}


	
	IEnumerator Fall(){
		yield return new WaitForSeconds(fallDelay);
		rb2d.isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = true;

		yield return new WaitForSeconds(3*fallDelay);
		rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(fallDelay);
		GetComponent<Collider2D> ().isTrigger = false;
		rb2d.isKinematic = true; 


		transform.position = originPosition;
		transform.rotation = originRotation;

		rb2d.constraints = RigidbodyConstraints2D.None;
		yield return 0;

	}
	
	
}
