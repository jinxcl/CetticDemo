using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemies : MonoBehaviour
{

    #region Public properties
    public Transform prefabEnemy;
    public GameObject player;
    public int numberOfEnemies;
    public float recycleOffset;
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
        startPosition = new Vector3(Random.Range(0, 4), 0, Random.Range(8, 16));
        //loop for amount of enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform g = (Transform)Instantiate(prefabEnemy);
            g.position = startPosition;
            //new position for enemies
            startPosition = new Vector3(Random.Range(0, 4), 0, Random.Range(8, 16));
            objectQueue.Enqueue(g);
        }

    }


    void Update()
    {
        //check de distance traveled by the player and check the position of first element in the quque widthout removing it
        //this part of the code generate more enemies on the map while the player traveled on it.
        if (objectQueue.Peek().localPosition.z + recycleOffset < characterScript.m_distanceTraveled)
        {
            Transform g = objectQueue.Dequeue();
            g.position = startPosition;
            startPosition = new Vector3(Random.Range(0, 4), 0, Random.Range(objectQueue.Peek().localPosition.z, objectQueue.Peek().localPosition.z + 40));
            objectQueue.Enqueue(g);
        }

    }
}
    #endregion
