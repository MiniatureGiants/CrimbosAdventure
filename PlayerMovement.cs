using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float jumpSpeed = 7f;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource runSnowSound;
    [SerializeField] AudioSource runPlatformSound;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    //BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;
    BoxCollider2D myFeetCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        

    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
        
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && playerHasHorizontalSpeed){
         if(!runSnowSound.isPlaying)
         {
            runSnowSound.Play();
            Debug.Log("running on snow");
         }

        }
        else if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")) && playerHasHorizontalSpeed){
         if(!runPlatformSound.isPlaying)
         {
            runPlatformSound.Play();
            Debug.Log("running on platforms");
         }
        }
        
        
    }

    void OnJump(InputValue value)
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Presents", "Platforms"))) 
        {
            return;
        }
        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            jumpSound.Play();
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
        

    }

}

