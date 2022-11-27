using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBag : MonoBehaviour
{
    Rigidbody2D bagRB;
    BoxCollider2D bagBC;
    [SerializeField] AudioSource bagPush;
    public bool bagIsMoving;
    void Start()
    {
        bagRB = GetComponent<Rigidbody2D>();
        bagBC = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (bagRB.velocity.x >= 2.5 || bagRB.velocity.x <= -2.5)
        {
            bagIsMoving = true;
        }
        else bagIsMoving = false;
    }

    public void OnCollisionStay2D(Collision2D other) 
   
    {
        if (bagIsMoving == true && other.gameObject.tag == "Player" && !bagPush.isPlaying)
        {
            bagPush.Play();
            Debug.Log("Bag is being pushed");
        }   
        else {Debug.Log("Something went wrong");}
    }

    public void OnCollisionExit2D(Collision2D other) 
    {
        bagIsMoving = false;
        bagPush.Stop();
        Debug.Log("Bag stopped");
    }    
}