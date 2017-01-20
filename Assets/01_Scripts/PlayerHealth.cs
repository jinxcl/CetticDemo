using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    #region Public properties
    public int livesAmount;
    public Text livesValue;
    public Text scoreValue;
    public Canvas gameOverCanvas;
    public AudioClip audioCrash;
    public GameObject item;
    #endregion


    #region properties
    private Text livesTextValue;
    private Text scoreTextValue;
    private ItemSettins itemSettings;
    private int scoreSum = 0;
    #endregion

    #region Unity monobehaviours

    void Start()
    {
        livesTextValue = livesValue.GetComponent<Text>();
        scoreTextValue = scoreValue.GetComponent<Text>();
        livesTextValue.text = livesAmount.ToString();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = audioCrash;
        itemSettings = item.GetComponent<ItemSettins>();
        
    }


    void Update()
    {

        if (livesAmount <= 0)
        {

            // .. then reload the currently loaded level.
            //Application.LoadLevel(Application.loadedLevel);
            livesTextValue.text = "GAME OVER";
            Time.timeScale = 0;
            gameOverCanvas.GetComponent<Canvas>().enabled = true;

        }
        


    }

    public void OnTriggerEnter(Collider other)
    {
        if (livesAmount <= 0)
            return;

        if (other.tag == "Enemy")
        {
            livesAmount = livesAmount - 1;
            livesTextValue.text = livesAmount.ToString();
            other.gameObject.SetActive(false);
            Destroy(other);
            GetComponent<AudioSource>().Play();
        }

        if (other.tag == "Item")
        {
            scoreSum = scoreSum + itemSettings.itemValue;
            scoreTextValue.text = scoreSum.ToString();
            other.gameObject.SetActive(false);
            Destroy(other);
        }

    }

    #endregion


}
