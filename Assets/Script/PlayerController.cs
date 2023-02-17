using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private bool canDoubleJump; // เพิ่มตัวแปรสำหรับเช็ค DoubleJump

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        canDoubleJump = true; // กำหนดค่าเริ่มต้นสำหรับ DoubleJump
    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                canDoubleJump = true; // เมื่อกระโดดครั้งแรกกำหนดให้สามารถ DoubleJump ได้
            }
            else if (canDoubleJump) // เช็คสำหรับ DoubleJump
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                canDoubleJump = false; // เมื่อ DoubleJump แล้วกำหนดให้ไม่สามารถ DoubleJump ได้อีก
            }
        }
    }
}
