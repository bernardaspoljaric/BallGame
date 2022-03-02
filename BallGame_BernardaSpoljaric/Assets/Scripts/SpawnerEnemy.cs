using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public GameManager gm;
    public float timer; 
    float timerReset;
    int spawnCount = 0;

    private void Start()
    {
        timerReset = timer;
        gm = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
            spawnCount++;
            timer = timerReset;
        }
        if (spawnCount == 10)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyMovement>().speed /= 0.85f;
            }
            spawnCount = 0;
        }

    }
}
