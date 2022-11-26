using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas myCanvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
        if (!myCanvas.enabled)
        {
            myCanvas.enabled = true;
            FindObjectOfType<GameStatus>().score = 0;
        }

              

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
