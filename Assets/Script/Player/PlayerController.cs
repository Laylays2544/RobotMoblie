using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;
    
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public float dashTime; //Dash
    public float dashSpeed; //Dash
    private float dashTimeLeft; //Dash

    private Collider2D myCollider;

    public GameManager theGamemanager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    public void Jump()
    {
        if (grounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            stoppedJumping = false;
        }
        if (!grounded && canDoubleJump)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            jumpTimeCounter = jumpTime;
            stoppedJumping = false;
            canDoubleJump = false;
        }
        if (!stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }

        }

        jumpTimeCounter = 0;
        stoppedJumping = true;

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }
    }

    public void Dash() //Method Dash System
    {
        if (dashTimeLeft <= 0)
        {
            dashTimeLeft = dashTime;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Start Update Dash System
        {
            Dash();
        }

        if (dashTimeLeft > 0)
        {
            moveSpeed = dashSpeed;
            dashTimeLeft -= Time.deltaTime;
        }
        else
        {
            moveSpeed = moveSpeedStore;
        } // End Line Update Dash System

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed + speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //RestartGame System
        if(other.gameObject.tag == "killbox")
        {
            theGamemanager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }

        //Dash System
        if (other.gameObject.CompareTag("DashPowerUp"))
        {
            Destroy(other.gameObject);
            dashTimeLeft = dashTime;
        }
    }
}
