using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PresentManager : MonoBehaviour
{
    [SerializeField] int presentPoint = 1;
    [SerializeField] AudioSource presentPickup;

   
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Present")
        {
            FindObjectOfType<GameStatus>().AddToSore(presentPoint);
            presentPickup.Play();
            Destroy(other.gameObject);
            Debug.Log("Collected a present");
        }
    }
}
