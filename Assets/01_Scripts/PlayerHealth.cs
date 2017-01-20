using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public int livesAmount;
    public Text livesValue;

    private Text livesTextValue;

    void Start()
    {
        livesTextValue = livesValue.GetComponent<Text>();
        livesTextValue.text = livesAmount.ToString();
        
    }


    void Update()
    {

        if (livesAmount <= 0)
        {

            // .. then reload the currently loaded level.
            //Application.LoadLevel(Application.loadedLevel);
            livesTextValue.text = "GAME OVER";
            Time.timeScale = 0;

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
        }

    }


}
