using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    public AudioClip audioCrash;

    void Start()
    {

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = audioCrash;

    }

    void OnCollisionEnter(Collision collision)//Plays Sound Whenever collision detected
    {

        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
        
    }




}
