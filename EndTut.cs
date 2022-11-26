using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTut : MonoBehaviour
{
    [SerializeField] TMP_Text push2Tut;
    [SerializeField] TMP_Text endTut;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        push2Tut.enabled = false;  
        endTut.enabled = true;
        Destroy(this);  
    }

}
