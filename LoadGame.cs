using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
[SerializeField] AudioSource introMusic;


void Start() 
{
    PlayIntroMusic();
}

public void StartGame()
{
    introMusic.Stop();
    SceneManager.LoadScene("Level 1");
    Debug.Log("Game Started");
}

public void PlayIntroMusic()
{
    if (introMusic.isPlaying) return;
    introMusic.Play();
}

}
