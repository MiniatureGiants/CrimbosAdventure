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
    
    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
        scoreText.text = score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        
        if (currentScene.buildIndex.Equals(1) && musicIsPlaying == false)
        {
            PlayMusic();
            Debug.Log("Restarted the game music");
        }
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
 }


