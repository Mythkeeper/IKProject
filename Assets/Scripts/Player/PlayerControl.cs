using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb; //rigidbody
    public float speed,jumpTime,checkRadius,jumpForce; // jump variables
    private float moveInput;  //self explanatory
    private bool isGrounded;  //to check if player is on the ground
    public Transform feetpos; //transform object to check for ground ground==anything on ground layer
    public LayerMask whatIsGround; //set ground layer mask
    private float jumpTimeCounter; //time counter
    private bool isJumping; 
    public Animator animator;
    public Position startingPosition; //scriptable object
   
   

    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>(); //reference to rigidbody
        transform.position=startingPosition.initialPosition; //initialize position
        
    }

    // Update is called once per frame
    void Update()
    {

       
        animator.SetFloat("Speed",Mathf.Abs(moveInput)); //make speed absolute
        isGrounded=Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround); // check players feet radius for ground , layermask to check for objects and ignore others, e.g water, sticky etc
       
       if(moveInput>0 )
       {
           transform.eulerAngles= new Vector3(0,0,0); //going right
       } 
       else if(moveInput<0)
       {
           transform.eulerAngles=new Vector3(0,180,0); // going left

       }
       
       
       
        if(isGrounded==true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping=true;//set to true when player first presses space key
            animator.SetBool("IsJumping", true); //this ISjumping is the paramterer added as a jumping condition for the animator 
            jumpTimeCounter=jumpTime; // set it to the value of the inspector
            rb.velocity = Vector2.up*jumpForce;
         }  //if isGrounded and presses space character should jump

        if(Input.GetKey(KeyCode.Space) && isJumping==true)
        {
            if(jumpTimeCounter >0)
            {  // so that player does not jump higher and higher
                rb.velocity = Vector2.up*jumpForce;
                jumpTimeCounter -=Time.deltaTime;
            } 
            else 
            {
                isJumping=false;
                animator.SetBool("IsJumping",false);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            animator.SetBool("IsJumping",false);
        }
        
        
    }

    



    void FixedUpdate()
    {
        moveInput= Input.GetAxisRaw("Horizontal"); //Getting horizontal input
        rb.velocity=new Vector2(moveInput*speed,rb.velocity.y);
    }





}

