using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private RectTransform[] spawnPoint;              // ��ȯ ��ġ

    private void Awake()
    {
        //Debug.Log( GetComponentsInChildren<RectTransform>().Length);
        spawnPoint = GetComponentsInChildren<RectTransform>();
    }

    public void Spawn(int num)
    {
        // ī�� ����� float ������ ��ȯ
        if(float.TryParse(GameManager.instance.AllCharacter_List[GameManager.instance.partySetCardIndex[num]].Cost, out float cardCost))
        {
            // ��ȯ ������ �ڿ��� ���� ��쿡�� ��ȯ ����
            if (FightManager.fightManager.curResourceMoney < cardCost) { return; }

            else if (FightManager.fightManager.curResourceMoney >= cardCost)
            {
                // ��� ����
                FightManager.fightManager.curResourceMoney -= cardCost;

                // ��ȯ
                GameObject character = FightManager.fightManager.characterPoolManager.Get(num);
                character.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length - 1)].transform.position;
            }
        }
    }
}
