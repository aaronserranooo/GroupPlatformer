using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFr : MonoBehaviour
{
public float moveSpeed;
public float jumpForce;
public Transform ceilingCheck;
public Transform groundCheck;

private Rigidbody2D rb;
private bool facingRight = true;
private float moveDirection;
private bool isJumping = false;
// Start is called before the first frame update

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update()
{

    Animate();



    ProcessInputs();
}
private void FixedUpdate()
{
    Move();
}
private void Move()
{
    rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    if (isJumping)
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isJumping = false;
    }

}
private void FlipCharacter()
{
    facingRight = !facingRight;
    transform.Rotate(0f, 180f, 0f);
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
private void ProcessInputs()
{
    moveDirection = Input.GetAxis("Horizontal");
    if (Input.GetButtonDown("Jump"))
    {
        isJumping = true;
    }

}
//POWER-UP
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
}
