using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float jumpForce;

    //public float dashSpeed;
    //public float dashDuration;
    //public float dashCooldown;

    //private bool isDashing;
    //private float dashTime;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        //isDashing = false;
        //dashTime = 0f;
    }
    
    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed + speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        

        //if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        //{
        //    if (grounded)
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //        canDoubleJump = true;
        //    }
        //    else if (canDoubleJump)
        //    {
        //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        //        canDoubleJump = false;
        //    }
        //}
    }

    public void Jump()
    {
        if (grounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }

        if (jumpTimeCounter > 0)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }

        jumpTimeCounter = 0;

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }
    }

    public void Dash()
    {
        //if (!isDashing && dashTime <= 0)
        //{
        //    isDashing = true;
        //    dashTime = dashDuration;
        //    myRigidbody.velocity = new Vector2(dashSpeed * Mathf.Sign(myRigidbody.velocity.x), myRigidbody.velocity.y);
        //    Debug.Log("Dashed");
        //}
        //if (isDashing)
        //{
        //    dashTime -= Time.deltaTime;
        //    if (dashTime <= 0)
        //    {
        //        isDashing = false;
        //        Debug.Log("Dash Ended");
        //    }
        //}

        //if (dashTime <= 0)
        //{
        //    dashTime = 0;
        //}
    }
}
