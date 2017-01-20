using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Public properties
    public GameObject player;
    public Text scoreValue;
    public Text timeValue;
    public Canvas gameOverCanvas;
    public int gameTime;
    #endregion

    #region private properties

    private ThirdPersonCharacter characterScript;
    private Text scoreTextValue;
    private Text timeTextValue;
    private Canvas _gameOverCanvas;

    #endregion

    #region Unity monobehaviour

    void Start()
    {

        //start position for enemies
        characterScript = player.GetComponent<ThirdPersonCharacter>();
        scoreTextValue = scoreValue.GetComponent<Text>();
        timeTextValue = timeValue.GetComponent<Text>();
        _gameOverCanvas = gameOverCanvas.GetComponent<Canvas>();
        _gameOverCanvas.enabled = false;
        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {

        //time since leel load, allow 30 Seconds by requirements
        timeTextValue.text = Time.timeSinceLevelLoad.ToString();


        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Time.timeSinceLevelLoad >= gameTime)
        {
            Time.timeScale = 0;
            _gameOverCanvas.enabled = true;
            timeTextValue.text = gameTime.ToString();
        }


    }

    #endregion
}
