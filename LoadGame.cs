using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
[SerializeField] AudioSource introMusic;

public bool gameStarted;

void Start() 
{
    PlayIntroMusic();
}

public void StartGame()
{
    introMusic.Stop();
    SceneManager.LoadScene("Level 1");
    gameStarted = true;
    Debug.Log("Game Started - set timer");
    FindObjectOfType<GameStatus>().timeLeft = 181;
}

public void PlayIntroMusic()
{
    if (introMusic.isPlaying) return;
    introMusic.Play();
}

}
