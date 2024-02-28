using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; 
    public int maxEnemies = 2; 

    private List<GameObject> enemyPool; 
    private Transform playerTransform; 
    private Vector3 spawnOffset = new Vector3(0f, 0f, 10f);
    private bool isMoving = false;

    void Start()
    {
        enemyPool = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject enemy = Instantiate(gameObject, GetRandomSpawnPosition(), Quaternion.identity);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }

        StartMoving();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    void StartMoving()
    {
        isMoving = true;
    }

    void StopMoving()
    {
        isMoving = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(20f, 30f));
        return playerTransform.position + randomOffset;
    }
}