using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Move")]
    //Player Move
    public float speed = 1f;

    //Component Define
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    //Gravity Control
    [Tooltip("Deneme")]
    public GameObject groundCheckObject;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundCheckLayer;

    //Jump
    public float jumpPower = 10f;
    private bool canJump = false;

    //Double Jump
    private int canDoubleJump = 0;

    public bool isRight;

    private void Start()
    {
        ComponentDefinition();
    }

    private void Update()
    {
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && canJump || Input.GetKeyDown(KeyCode.Space) && canDoubleJump < 1)
        {
            myRigidbody.AddForce(new Vector2(0f, jumpPower));
            myAnimator.SetTrigger("isJump");
            //Double Jump
            canDoubleJump++;
        }
    }

    private void FixedUpdate()
    {
        //Ground Control
        GroundChecker();

        //Player Move
        float moveInput = Input.GetAxis("Horizontal");
        float moveVelocity = moveInput * speed;

        if(moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isRight = false;
        }
        else if(moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isRight = true;
        }

        myAnimator.SetFloat("speed", Mathf.Abs(moveInput));

        myRigidbody.velocity = new Vector2(moveVelocity, myRigidbody.velocity.y);
    }

    private void GroundChecker()
    {
        if (Physics2D.OverlapCircle(groundCheckObject.transform.position, groundCheckRadius, groundCheckLayer))
        {
            canDoubleJump = 0;
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }


    private void ComponentDefinition()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

}
