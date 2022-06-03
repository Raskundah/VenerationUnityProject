using System;
using System.Collections;
using System.Collections.Generic;
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
    private BoxCollider2D boxCollider = null;
    




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
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
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
            float jumpVel = 3f;

            physicsBody.velocity = newVel * jumpVel;
            isJumping = true;

        }

    }
    
    public void MoveDown() // this Method now attacks. DOES NOT MOVE DOWN.
    {
        /*Debug.Log("Move Down Button Pressed!");
        Vector2 newVel = new Vector2(0, -moveSpeed);
        physicsBody.velocity = newVel; */

        if (hasSword)
        {
            animator.SetBool("Attacking", true);
            isAttacking = true;
        }
        
        
    }

    public void MoveRight()
    {
        Debug.Log("Move Right Button Pressed!");
        isFlipped = false;
        

        Vector2 newVel = new Vector2(moveSpeed, 0);

        animator.SetBool("Walking", true);

        physicsBody.velocity = newVel;
    }

    public void MoveLeft()
    {
        Debug.Log("Move Left Button Pressed!");
        isFlipped = true;

        Vector2 newVel = new Vector2(- moveSpeed, 0);
        animator.SetBool("Walking", true);

        physicsBody.velocity = newVel;
        
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
        
    }

   /* private bool IsGrounded()
    {
        var bounds = boxCollider.bounds;
        RaycastHit2D rayCastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down * .1f, platformsLayerMask);
        return rayCastHit.collider != null;
    }
    
    */


}
