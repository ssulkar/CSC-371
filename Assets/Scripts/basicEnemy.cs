using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemy : MonoBehaviour {

    public int EnemySpeed = 5;
    public int xMove = 1;
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * EnemySpeed;

        if(hit.distance < 1.0f)
        {
            Flip();
        }
	}

    void Flip()
    {
        if(xMove > 0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
    }
}
