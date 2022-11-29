using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class timer : MonoBehaviour
{
    public float countDown;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource timesAlmostUp;
    public bool timesNearlyUp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        countDown = FindObjectOfType<GameStatus>().timeLeft;

        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
            Debug.Log("Timer started, counting down");
        }

        else
        {
            countDown = 0;
            Debug.Log("Game has Ended");
            
        }
        if (countDown == 0)
        {
            SceneManager.LoadScene("EndScene");
            Debug.Log("Timer has expired");
        }

        DisplayTime(countDown);
        
    }

     void DisplayTime (float timeToDisplay)
     {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes == 0 && seconds < 31)
        {
            timerText.color = new Color32(255, 35, 35, 255);
            
        }
        if (minutes == 0 && seconds == 30 && timesNearlyUp == false)
        {
            timesNearlyUp = true;
            timesAlmostUp.Play();
        }

     }

}
