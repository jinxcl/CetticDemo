﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
