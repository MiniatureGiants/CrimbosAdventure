using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pushScript : MonoBehaviour
{

    Rigidbody2D presentRB;
    BoxCollider2D presentBC;
    [SerializeField] AudioSource snowPush;
    [SerializeField] AudioSource woodPush;
    public bool presentIsMoving;
    void Start()
    {
        presentRB = GetComponent<Rigidbody2D>();
        presentBC = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (presentRB.velocity.x >= 2.5 || presentRB.velocity.x <= -2.5)
        {
            presentIsMoving = true;
        }
        else presentIsMoving = false;
    }

    public void OnCollisionStay2D(Collision2D other) 
   
    {
        if (presentIsMoving == true && other.gameObject.tag == "Player" && !snowPush.isPlaying && (presentBC.IsTouchingLayers(LayerMask.GetMask("Ground"))))
        {
            snowPush.Play();
            Debug.Log("Present being pushed");
        }
        else if (presentIsMoving == true && other.gameObject.tag == "Player" && !woodPush.isPlaying && (presentBC.IsTouchingLayers(LayerMask.GetMask("Platforms"))))
        {
            woodPush.Play();
            Debug.Log("Present being pushed");
        }   
    }

    public void OnCollisionExit2D(Collision2D other) 
    {
        presentIsMoving = false;
        snowPush.Stop();
        woodPush.Stop();
        Debug.Log("Present stopped");
    }    
}

