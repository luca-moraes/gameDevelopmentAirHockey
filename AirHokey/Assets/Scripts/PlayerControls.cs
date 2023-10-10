using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
  public KeyCode moveUp = KeyCode.W;
  public KeyCode moveDown = KeyCode.S;
  public float speed = 10.0f;
  public float boundY = 2.25f;
  private Rigidbody2D rb2d;

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();    
  }

  void Update()
  {
    var vel = rb2d.velocity;
    vel.y = speed*0.5f;
    rb2d.velocity = vel;

    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    var pos = transform.position;

    pos.y = mousePos.y;
    transform.position = pos;
  }
}

