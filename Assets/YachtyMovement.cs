using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YachtyMovement : MonoBehaviour {
	
	public Transform[] positions;
	public float speed;
	public Transform[] barrel;
	public GameObject projectile;


	private float fireRate = 0.8f;
	private float coolDown = 0f;
	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		StartCoroutine ("bossPattern");
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator bossPattern(){
		while (true) {
			//move
			while (transform.position != positions [0].position) {
				//Vector2 nextPosition = new Vector2 (positions [0].position.x, transform.position.y);
				transform.position = Vector2.MoveTowards (transform.position, positions[0].position, speed);
				if (Time.time > coolDown) {
					coolDown = Time.time + fireRate;
					GameObject projectileObj = (GameObject)Instantiate (projectile, barrel [0].position, Quaternion.identity);
					projectileObj.GetComponent<Rigidbody2D> ().velocity = Vector2.left * 7;
				}
				yield return null;
			}
			print ("g");
			anim.SetBool ("isGrounded", true);
			yield return new WaitForSeconds (2f);
			print ("here");
			anim.SetBool ("isGrounded", false);
			while (transform.position != positions [1].position) {
				transform.position = Vector2.MoveTowards (transform.position, positions [1].position, speed);
				if (Time.time > coolDown) {
					coolDown = Time.time + fireRate;
					GameObject projectileObj = (GameObject)Instantiate (projectile, barrel [0].position, Quaternion.identity);
					projectileObj.GetComponent<Rigidbody2D> ().velocity = Vector2.left * 7;
				}
				yield return null;
			}
			yield return new WaitForSeconds (2f);
		}
	}
}