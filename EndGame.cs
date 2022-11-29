using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    GameStatus gameStatus;
    public int finalScore;

    

    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI scoreBreakdown;

    void Awake() 
    {
        
    }

    void Start()
    {
        finalScore = FindObjectOfType<GameStatus>().score;
        GameObject.Find("UICanvas").GetComponent<Canvas>().enabled = false;
        Debug.Log("You scored: " + finalScoreText.text);
        float timeRemaining = FindObjectOfType<GameStatus>().timeLeft;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        

        if (finalScore == 21)
        {
            finalScoreText.text = "Crimbo saved Christmas that year. Every child found a present under the tree on Christmas morning and the day was filled with joy and fun. " +
            "Santa was so proud of little Crimbo that he made him Chief Present Controller.";
        }
        else if (finalScore <= 20 && finalScore >= 17)
        {
            finalScoreText.text = "Christmas was good that year. Still, it felt strangely like something was missing. But there were enough presents to unwrap on Christmas day that " +
            "everyone soon forgot that strange feeling and went on to thoroughly enjoy their Christmas. Well done, Crimbo.";
        }
        else if (finalScore <= 16 && finalScore >= 4) 
        {
        finalScoreText.text = "That year there was much dissapointment on Christmas morning. Dreams remained just that...dreams. And the promise of what Santa would deliver " +
        "never materialised. Poor Crimbo had failed to save Christmas, and Santa banished him to work in a Chocolate Factory instead.";
        }
        else 
        {
        finalScoreText.text = "'You didn't even try to save Christmas, did you Crimbo?' Santa asked with dissapointment. Crimbo had proven to be utterly useless in his quest to save " +
        " Christmas. 'You had ONE job!'. Crimbo was banished to the Black Wall, never to experience Christmas ever again";
        }

        scoreBreakdown.text = ("You found " + finalScore.ToString() + " presents and had " + string.Format("{0:00}:{1:00}", minutes, seconds) + " second left. Post your best time!");
    }
    public void LoadMainMenu()
    {
        //Notes: the score variable is a PUBLIC int, so it can be found directly with below line of code
        //the Score TEXT is a [SerializedField] in the GameStatus (singleton) script which is NOT public, so FindObjectOfType<GameStatus> didnt work
        //instead it seems if I find the object directly, which is a TextMeshProGUI game object on the canvas under GameStatus game object, then it works
        //Before starting a new game, both the SCORE int and the Score TEXT need to be set to 0
        //Also need to stop the music from playing in the singleton so that it doesnt play with the intro music on the main screen.

        FindObjectOfType<GameStatus>().StopMusic();
        FindObjectOfType<GameStatus>().score = 0;
        FindObjectOfType<GameStatus>().timesUp = true;
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "0";
        SceneManager.LoadScene("Menu");

    }
}
