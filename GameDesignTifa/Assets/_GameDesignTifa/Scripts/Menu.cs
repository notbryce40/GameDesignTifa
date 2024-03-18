using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource audio;
    
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
        
    }

    public void OnQuitButton()
    {
        Application.Quit();
        
    }

    public void playNoise()
    {
        audio.Play();
    }
}
