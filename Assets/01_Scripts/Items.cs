using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Items : MonoBehaviour {


    //This code is exactly the same as Enemies, with some modification, not procedural.
    #region Public properties
    public Transform prefabItem;
    public GameObject player;
    public int numberOfEnemies;
    #endregion

    #region Private properties
    private Queue<Transform> objectQueue;
    private Vector3 startPosition;
    private ThirdPersonCharacter characterScript;
    #endregion

    #region Unity behaviour
    void Start()
    {
        //Define a queue with enemies
        objectQueue = new Queue<Transform>(numberOfEnemies);
        //start position for enemies
        characterScript = player.GetComponent<ThirdPersonCharacter>();
        //startPosition of enemies on the plataform
        startPosition = new Vector3(Random.Range(-2, 4), 0, Random.Range(10, 200));
        //loop for amount of enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform g = (Transform)Instantiate(prefabItem);
            g.position = startPosition;
            //new position for enemies
            startPosition = new Vector3(Random.Range(0, 4), 0, Random.Range(10, 200));
            objectQueue.Enqueue(g);
        }

    }


    void Update()
    {


    }

    #endregion
}
