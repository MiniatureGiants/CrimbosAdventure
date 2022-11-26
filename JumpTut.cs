using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JumpTut : MonoBehaviour
{
   
    [SerializeField] TMP_Text jumpTut;
    [SerializeField] TMP_Text pushTut;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        jumpTut.enabled = false;  
        pushTut.enabled = true;
        Destroy(this);  
    }


}
