using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{

    [SerializeField] AudioSource music;
    [SerializeField] TextMeshProUGUI scoreText;

    public int score = 0;
    public bool musicIsPlaying = true;

    public bool timesUp;
    public float timeLeft;

    public bool startingANewGame;
        
    private void Awake()
    {
        
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("Destroyed the active game object");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
        }      
    }
    

    void Start()
    {
        PlayMusic();
        scoreText.text = score.ToString();
    
    }


    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        
        if (currentScene.buildIndex.Equals(1) && musicIsPlaying == false)
        {
            PlayMusic();
            Debug.Log("Restarted the game music");
        }

        ManageTime();

    }

    public void PlayMusic()
     {
         if (music.isPlaying) return;
         music.Play();
         musicIsPlaying = true;
     }
 
     public void StopMusic()
     {
         music.Stop();
         musicIsPlaying = false;
     
     }

    public void AddToSore(int pointsToAdd)
     {
        score += pointsToAdd;
        scoreText.text = score.ToString();
     }
    
    public void ManageTime()
    {
        //How does the timer work? This was complicated. Originally tried to have all of this functionality inside this singleton, however there were big issues in
        //getting the final scene to load, and in some instances when trying to use a co-routine, Unity almost crashes. So here's how this works:
        //timeLeft is a public int variable, and the initial value is set in the Unity Inspector GameStatus game object. The GameStatus object/singleton is attached to the first
        //level and the below code will start executing when the Play button is pushed and LoadGame script loads the first level. There is a seperate "Timer" game object prefab which
        //has been added to every scene. On it is a Canvas with the Timer TMPRO text, and a script. This script (timer.cs) has an int variable called countDown that gets its value
        //based on the timeLeft value in this script, and then per below, both values start counting down. At the end of the game, there was a challenge in resetting the timer.
        //This has been solved in the AddGameTime method below where we check if timesUp is true (set on the EndGame screen b EndGame.cs) which adds a huge allocation of time for a
        //player to sit on the main screen and choose to play the game. When they click Play for the second time, the LoadGame.cs script will reset the timeLeft value here to 181s
        //I dont know what it works the second time around and not the first time you play, but it probably has something to do with the singleton. Anyway, this works, so there you go.

        if (timeLeft > 0 && timesUp == false)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log("Counting down");
        }

        else 
        {
            timeLeft = 0;
            timesUp = true;
            Debug.Log("No more time left in the game");
            AddGameTime();
        }

    }

    public void AddGameTime()
    {
       
       if (timesUp == true)
        {
            timeLeft = 360;
            Debug.Log("Allocating time for a new game");
            timesUp = false;
            startingANewGame = true;
        }

    }
}
 



