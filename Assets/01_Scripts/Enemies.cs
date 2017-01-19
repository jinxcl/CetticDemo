using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemies : MonoBehaviour
{


    public Transform prefabEnemy;
    public GameObject player;
    public int numberOfEnemies;
    public float recycleOffset;



    private Queue<Transform> objectQueue;
    private Vector3 startPosition;
    private ThirdPersonCharacter characterScript;

    void Start()
    {

        objectQueue = new Queue<Transform>(numberOfEnemies);
        //start position for enemies
        characterScript = player.GetComponent<ThirdPersonCharacter>();
        startPosition = new Vector3(Random.Range(0, 4), 0, Random.Range(8, 16));
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

        if (objectQueue.Peek().localPosition.z + recycleOffset < characterScript.m_distanceTraveled)
        {
            Transform g = objectQueue.Dequeue();
            g.position = startPosition;
            startPosition = new Vector3(Random.Range(0, 4), 0, Random.Range(objectQueue.Peek().localPosition.z, objectQueue.Peek().localPosition.z + 40));
            objectQueue.Enqueue(g);
        }

    }
}
