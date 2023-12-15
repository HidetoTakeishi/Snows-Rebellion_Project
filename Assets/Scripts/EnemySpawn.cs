using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject SnowMan;
    public float spawnRate = 2.0f;
    public int maxEnemy = 10;

    private float nextSpawntime;
    private BoxCollider spawnArea;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnArea = GetComponent<BoxCollider>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.IsGameover && !gameManager.IsGameclear)
        {
            if (Time.time > nextSpawntime && GameObject.FindGameObjectsWithTag("SnowMan").Length < maxEnemy)
            {
                SpawnEnemy();
                nextSpawntime = Time.time + spawnRate;
            }
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(transform.position.x - spawnArea.size.x / 2, transform.position.x + spawnArea.size.x / 2),
            transform.position.y,
            Random.Range(transform.position.z - spawnArea.size.z / 2, transform.position.z + spawnArea.size.z / 2)
        );

        Instantiate(SnowMan, randomPosition, Quaternion.identity);
    }
}
