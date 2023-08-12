using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemySpawnPoint;

    float timer = 2f;

    private void Awake()
    {
        enemySpawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            EnemySpawn();
            timer = 0f;
        }
    }

    void EnemySpawn()
    {
        GameObject enemy = FightManager.fightManager.enemyPoolManager.Get(Random.Range(0, 2));

        enemy.transform.position = enemySpawnPoint[Random.Range(1, enemySpawnPoint.Length)].transform.position;
    }
}

