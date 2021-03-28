using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed,jumpTime,checkRadius,jumpForce;
    private float moveInput;
    private bool isGrounded;//to check if player is on the ground
    public Transform feetpos;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    private bool isJumping;
    public Animator animator;
    public Position startingPosition;
   

    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        transform.position=startingPosition.initialPosition;
        
    }

    // Update is called once per frame
    void Update()
    {

        
        animator.SetFloat("Speed",Mathf.Abs(moveInput));
        isGrounded=Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround); // check players feet radius for ground , layermask to check for objects and ignore others, e.g water, sticky etc
       
       if(moveInput>0 ){
           transform.eulerAngles= new Vector3(0,0,0);
       } 
       else if(moveInput<0){
           transform.eulerAngles=new Vector3(0,180,0);

       }
       
       
       
        if(isGrounded==true && Input.GetKeyDown(KeyCode.Space)){
            isJumping=true;//set to true when player first presses space key
            animator.SetBool("IsJumping", true); //this ISjumping is the paramterer added as a jumping condition for the animator 
            jumpTimeCounter=jumpTime; // set it to the value of the inspector
            rb.velocity = Vector2.up*jumpForce;
            }//if isGrounded and presses space character should jump

        if(Input.GetKey(KeyCode.Space) && isJumping==true){
            if(jumpTimeCounter >0){  // so that player does not jump higher and higher
                rb.velocity = Vector2.up*jumpForce;
                jumpTimeCounter -=Time.deltaTime;
            } 
            else {
                isJumping=false;
                animator.SetBool("IsJumping",false);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space)){
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

