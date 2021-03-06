﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateController : GameManager
{
    private AudioSource adSource;
    public void Awake()
    {
        adSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {                
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);              
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
