using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;
    public float jumpForce;

    public float moveSpeed;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    public Rigidbody2D rb;

    // Awake is called after all objects are initialized. Called in a Random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//Will look for a component on this Game Object(what the script is attached to)of type Rigidbody2d

    }

    // Update is called once per frame
    void Update()
    {
        //get input
        MoveLeftRight();

        //animate
        Animate();
        //Move
        Move();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        isJumping = false;

    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void MoveLeftRight()
    {
        moveDirection = Input.GetAxis("Horizontal");//Scale of -1 -> 1
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }
    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }

    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 9;
        yield return new WaitForSeconds(5);
        moveSpeed = 5;
    }

    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
