using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3 (0, 45, 0) * Time.deltaTime * 1.5f);
	}
}
