using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour

{
    [SerializeField] private LayerMask platformsLayerMask;
    public float moveSpeed = 10.0f;
    public static bool isFlipped = false;
    private static bool isJumping = false;
    private static bool hasSword = false;
    [SerializeField] public static bool isAttacking = false;

    private Rigidbody2D physicsBody = null;
    private Animator animator = null;
    private BoxCollider2D boxCollider ;
    public BoxCollider2D swordCollider;
    private float timer = 15f;
    private static Player instance;
    private bool isGrounded = true;
    private double swingTimer;
    private double jumpTimer = 0d;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }
            
    }


    // Start is called before the first frame update
    void Start()

    {

        physicsBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        // physicsBody.velocity = new Vector2(2, 0);

        // Update is called once per frame
    }

    // Update is called once per frame
    void Update()

    // Ask unity input manager for the current value of the horizontal/Vertical axis
    // will be between -1 and 1
    
    
    {

        if(jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }
            
        
       
        /*
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            isAttacking = false;
            swordCollider.enabled = false;

        }
      */

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            swordCollider.enabled = false;
            isAttacking = false;
        }

        
        float axisValX = Input.GetAxis("Horizontal");
        float axisValY = Input.GetAxis("Vertical");
        Vector2 newVel = new Vector2(axisValX, axisValY);
        newVel *= moveSpeed;
        // physicsBody.velocity = newVel;

        // Vector2 currentVel = physicsBody.velocity;
        // animator.SetFloat("Vertical", currentVel.y)

        if (Mathf.Abs(physicsBody.velocity.x) < 0.3f)
        {
            animator.SetBool("Walking", false);
        }
        
        


    }
    
    

    public void MoveUp() // THIS IS NOW THE JUMP METHOD.
    {
        if (!isJumping)
        {

            Debug.Log("Move Up Button Pressed!");
            Vector2 newVel = new Vector2(0, moveSpeed);
            animator.SetBool("Jumping", true);
            float jumpVel = 5f;

            physicsBody.velocity = newVel * jumpVel;
            isJumping = true;

        }

    }
    
    public void MoveDown() // this Method now attacks. DOES NOT MOVE DOWN.
    {
        /*Debug.Log("Move Down Button Pressed!");
        Vector2 newVel = new Vector2(0, -moveSpeed);
        physicsBody.velocity = newVel; */

        if (hasSword && !isAttacking)
        {
            animator.SetBool("Attacking", true);
            isAttacking = true;
            timer = 0.3f;
            swordCollider.enabled = true;
        }

       /* if (swingTimer >= 0)
        {
            isAttacking = false;
        }

        else
        {
            swingTimer = 0.5d;
        }

        swingTimr -= Time.deltaTime;

        */

        
    }

    public void MoveRight()
    {
        if (isGrounded)
        {

            Debug.Log("Move Right Button Pressed!");
            isFlipped = false;


            Vector2 newVel = new Vector2(moveSpeed, 0);

            animator.SetBool("Walking", true);

            physicsBody.velocity = newVel;
        }
    }

    public void MoveLeft()
    {
        if (isGrounded)
        {
            Debug.Log("Move Left Button Pressed!");
            isFlipped = true;

            Vector2 newVel = new Vector2(-moveSpeed, 0);
            animator.SetBool("Walking", true);

            physicsBody.velocity = newVel;
        }

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        GameObject gameObject = col.gameObject;

        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        if (gameObject != null)
        {
            isJumping = false;
        }

        if (gameObject.CompareTag("Sword"))
        {
            hasSword = true;
            Destroy(gameObject);

        }
        
        if(col.gameObject.tag == "Enemy" && isAttacking)
        {
            Destroy(col.gameObject);
        }

        if (gameObject.layer == 8)
        {

            isGrounded = true;
            jumpTimer = 2;
        }
        
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        GameObject gameObject = other.gameObject;

        if (gameObject.layer == 8)
        {
            

            if (jumpTimer <= 0)

            {
                jumpTimer = 1d;
                isGrounded = false;
            }
 
            
                  
        }
    }

    /* private bool IsGrounded()
    {
        var bounds = boxCollider.bounds;
        RaycastHit2D rayCastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down * .1f, platformsLayerMask);
        return rayCastHit.collider != null;
    }
    
    */


}
