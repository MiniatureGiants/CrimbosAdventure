using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioSource levelExit;
    [SerializeField] Animator fadeAnimator;
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Bag")
        {
            levelExit.Play();
            fadeAnimator.SetTrigger("FadeOut");
            Debug.Log("loading next level");
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        fadeAnimator.SetTrigger("FadeIN");
        Debug.Log("Ran the fade-in");  
    }
}
