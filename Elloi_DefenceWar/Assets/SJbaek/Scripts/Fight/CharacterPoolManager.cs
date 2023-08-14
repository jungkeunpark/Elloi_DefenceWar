using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPoolManager : MonoBehaviour
{
    // 오브젝트 풀에서 필요한 것
    // 1. 프리팹들을 보관할 변수
    // 2. 풀을 담당하는 리스트 ( 프리팹 1개당 리스트 1개 )

    // 변수
    public GameObject[] characterPrefabs;

    // 리스트
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[characterPrefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

        // 각각의 캐릭터에 값 주기
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
