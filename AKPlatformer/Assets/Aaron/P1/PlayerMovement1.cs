using System.Collections;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{   //jump force
    public float jumpForce;
    //creates a storage location for how fast we want our player to go. 
    public float moveSpeed = 6;
    //storage location for moving left and right via input
    public float moveDirection;
    //ceiling check
    public Transform ceilingCheck;
    //ground check
    public Transform groundCheck;
    //stores and set a our layermasks
    public LayerMask groundObjects;
    public int maxJumpCount;
    public int jumpCount;
    //storage location for our rigidbody2d
    private Rigidbody2D rb;
    // bool to tell which way our player is facing
    private bool facingRight = true;
    //stores if jumping or not
    private bool isJumping;
    private bool isGrounded;


    private void Start()
    {
        jumpCount = maxJumpCount;
    }
    private void Awake()
    {
        //grabs the rigidbody2D 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input
        ProcessInputs();
        //Animate
        Animate();
    }

    //all physics handling should go in Fixed Update
    private void FixedUpdate()
    {
        //check to see if we are grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        //move
        MoveRB();
    }

    private void MoveRB()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping && jumpCount > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCount--;

        }
        isJumping = false;

        float timeReset = Time.time;
        if (timeReset >= timeReset + 5)
        {

            maxJumpCount = 1;
        }
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
        moveDirection = Input.GetAxis("Horizontal"); // -1 and 1

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    //create a method that will flip our character based off of direction
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

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
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
