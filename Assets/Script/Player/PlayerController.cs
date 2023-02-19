using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private bool canDoubleJump; // เพิ่มตัวแปรสำหรับเช็ค DoubleJump
    private bool isDashing;
    private float dashTime;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        canDoubleJump = true; // กำหนดค่าเริ่มต้นสำหรับ DoubleJump
        isDashing = false;
        dashTime = 0f;
    }
    public void Jump()
    {
        Debug.Log("Jumped");
        if (grounded)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            canDoubleJump = false;
            Debug.Log("Double Jumped");
        }
    }

    public void Dash()
    {
        if (!isDashing && dashTime <= 0)
        {
            isDashing = true;
            dashTime = dashDuration;
            myRigidbody.velocity = new Vector2(dashSpeed * Mathf.Sign(myRigidbody.velocity.x), myRigidbody.velocity.y);
            Debug.Log("Dashed");
        }
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                isDashing = false;
                Debug.Log("Dash Ended");
            }
        }

        if (dashTime <= 0)
        {
            dashTime = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (!isDashing)
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        }

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

        //if (Input.GetKeyDown(KeyCode.Q) && !isDashing && dashTime <= 0)
        //{
        //    isDashing = true;
        //    dashTime = dashDuration;
        //    myRigidbody.velocity = new Vector2(dashSpeed * Mathf.Sign(myRigidbody.velocity.x), myRigidbody.velocity.y);
        //}

        //if (isDashing)
        //{
        //    dashTime -= Time.deltaTime;
        //    if (dashTime <= 0)
        //    {
        //        isDashing = false;
        //    }
        //}

        //if (dashTime <= 0)
        //{
        //    dashTime = 0;
        //}
    }
    //public void Jump()
    //{
    //    Debug.Log("Jumped");
    //    if (grounded)
    //    {
    //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
    //        canDoubleJump = true;
    //    }
    //    else if (canDoubleJump)
    //    {
    //        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
    //        canDoubleJump = false;
    //        Debug.Log("Double Jumped");
    //    }
    //}

    //public void Dash()
    //{
    //    if (!isDashing && dashTime <= 0)
    //    {
    //        isDashing = true;
    //        dashTime = dashDuration;
    //        myRigidbody.velocity = new Vector2(dashSpeed * Mathf.Sign(myRigidbody.velocity.x), myRigidbody.velocity.y);
    //        Debug.Log("Dashed");
    //    }
    //    if (isDashing)
    //    {
    //        dashTime -= Time.deltaTime;
    //        if (dashTime <= 0)
    //        {
    //            isDashing = false;
    //            Debug.Log("Dash Ended");
    //        }
    //    }

    //    if (dashTime <= 0)
    //    {
    //        dashTime = 0;
    //    }
    //}
}
