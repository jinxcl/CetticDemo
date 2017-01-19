using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ProceduralGround : MonoBehaviour
{

    public Transform prefabGround;
    public int numberOfObject;
    public Vector3 startPosition;
    public float recycleOffset;
    public GameObject player;

    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;
    private ThirdPersonCharacter characterScript;
    


    void Start()
    {
                
        characterScript = player.GetComponent<ThirdPersonCharacter>();
         
        objectQueue = new Queue<Transform>(numberOfObject);
        nextPosition = startPosition;
        for (int i = 0; i < numberOfObject; i++)
        {
            Transform g = (Transform)Instantiate(prefabGround);
            g.position = nextPosition;
            nextPosition = nextPosition + new Vector3(0, 0, 8);
            objectQueue.Enqueue(g);
        }

    }

    
    void Update()
    {

        //Debug.Log(objectQueue.Peek().localPosition.z + recycleOffset);
        if(objectQueue.Peek().localPosition.z + recycleOffset < characterScript.m_distanceTraveled)
        {
            Transform g = objectQueue.Dequeue();
            g.position = nextPosition;
            nextPosition = nextPosition + new Vector3(0, 0, 8);
            objectQueue.Enqueue(g);
        }
    }
}
