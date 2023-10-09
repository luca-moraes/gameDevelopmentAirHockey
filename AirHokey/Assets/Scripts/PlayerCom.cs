using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCom : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float partialSpeed = 0.05f;
    public float boundY = 2.25f;
    // private bool subindo;
    private Rigidbody2D rb2d;
    private GameObject ball;

    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();    
        // subindo = Random.Range(0, 2) == 1 ? true : false;
        ball = GameObject.FindGameObjectWithTag("TagBall");
    }



    void Update()
    {
     	var vel = rb2d.velocity;
		
		// if (Input.GetKey(moveUp)) {
		// 	vel.y = speed;
		// }
		// else if (Input.GetKey(moveDown)) {
		// 	vel.y = -speed;
		// }
		// else {
			if (ball.transform.position.y > transform.position.y) {
			    vel.y = partialSpeed*0.6f;
            }
            else{
                vel.y = -partialSpeed*0.6f;
            }
		// }

		rb2d.velocity = vel;
		var pos = transform.position;

		if (pos.y > boundY) {
			pos.y = boundY;
            // subindo = false;
		}
		else if (pos.y < -boundY) {
			pos.y = -boundY;
            // subindo = true;
		}

		transform.position = pos;
    }
}