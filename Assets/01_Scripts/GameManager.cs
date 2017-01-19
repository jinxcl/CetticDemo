using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public Text scoreValue;
    public Text timeValue;

    private ThirdPersonCharacter characterScript;
    private Text scoreTextValue;
    private Text timeTextValue;

	void Start () {

        //start position for enemies
        characterScript = player.GetComponent<ThirdPersonCharacter>();
        scoreTextValue = scoreValue.GetComponent<Text>();
        timeTextValue = timeValue.GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

        scoreTextValue.text = characterScript.m_distanceTraveled.ToString();
        timeTextValue.text = Time.realtimeSinceStartup.ToString();
		
	}
}
