using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    public void Spawn(int num)
    {
        GameObject character = FightManager.fightManager.characterPoolManager.Get(num);

        character.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].transform.position;
    }
}
