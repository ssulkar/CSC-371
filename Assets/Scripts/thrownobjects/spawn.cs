using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
	public GameObject[] thrownObject;
	private int posRandRange = 10;
	private float maxForcey = 18;
	private float minForcey = 9;

	private float maxForcex = 23;
	private float minForcex = 11;


	private float period = 2.0f; // 2 seconds
	private float nextActionTime = 0.0f;
	private Transform randTrans;
	private GameObject curr;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		nextActionTime = Time.time + period;
	}

	void Update(){
		if (Time.time >= nextActionTime && transform.position.x < 178) {

			nextActionTime = Time.time + period;

			int i = Random.Range (0, thrownObject.Length);

			randTrans = gameObject.transform;
			float posX1 = randTrans.position.x - posRandRange;
			float posX2 = randTrans.position.x + posRandRange;
			float posY1 = randTrans.position.y - posRandRange;
			float posY2 = randTrans.position.y + posRandRange;

			float currX = Random.Range ((int)posX1, (int)posX2);
			float currY = Random.Range ((int)posY1, (int)posY2);


			float fx = Random.Range (minForcex, maxForcex);
			float fy = Random.Range (minForcey, maxForcey);




			curr = Instantiate (thrownObject[i], new Vector3 (currX, currY, randTrans.position.z), randTrans.rotation);
			rb = curr.GetComponent<Rigidbody2D> ();
			rb.AddForce (new Vector2(fx, fy), ForceMode2D.Impulse);

		}
	}
} 
