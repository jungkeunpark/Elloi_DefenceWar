using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPoolManager : MonoBehaviour
{
    // ������Ʈ Ǯ���� �ʿ��� ��
    // 1. �����յ��� ������ ����
    // 2. Ǯ�� ����ϴ� ����Ʈ ( ������ 1���� ����Ʈ 1�� )

    // ����
    public GameObject[] characterPrefabs;

    // ����Ʈ
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[characterPrefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

        // ������ ĳ���Ϳ� �� �ֱ�
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            PlayerCharacter playerCharacter = characterPrefabs[i].GetComponent<PlayerCharacter>();
            playerCharacter.SetCharacterCardValues(i);
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
                break;
            }
        }

        if (select == null)
        {
            select = Instantiate(characterPrefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
