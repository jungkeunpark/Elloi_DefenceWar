using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    // ������Ʈ Ǯ���� �ʿ��� ��
    // 1. �����յ��� ������ ����
    // 2. Ǯ�� ����ϴ� ����Ʈ ( ������ 1���� ����Ʈ 1�� )

    // ����
    public GameObject[] enemyPrefabs;

    // ����Ʈ
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[enemyPrefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject character in pools[index])
        {
            if (character.activeSelf == false)
            {
                select = character;
                select.SetActive(true);
                FightManager.fightManager.activeEnemys.Add(select);
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(enemyPrefabs[index], transform);
            pools[index].Add(select);
            FightManager.fightManager.activeEnemys.Add(select);
        }

        return select;
    }
}

