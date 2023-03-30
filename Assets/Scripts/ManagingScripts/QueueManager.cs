using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField]
    private float currentTime;

    public float minimumRespawnTime;
    public float maximumRespawnTime;
    public float respawnTime;
    private GameObject[] queueObjects;

    private void Awake()
    {
        queueObjects = GameObject.FindGameObjectsWithTag("Q");
        respawnTime = Random.Range(minimumRespawnTime, maximumRespawnTime);
    }

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= respawnTime)
        {
            SpawnCustomerInRandomQueue();
            currentTime = 0f;
        }
    }

    private void SpawnCustomerInRandomQueue()
    {
        QueueController queue = queueObjects[Random.Range(0, queueObjects.Length)].GetComponent<QueueController>();
        queue.SpawnCustomer();
    }

}
