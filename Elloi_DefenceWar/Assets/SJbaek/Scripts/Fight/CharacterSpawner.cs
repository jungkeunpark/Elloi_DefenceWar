using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private RectTransform[] spawnPoint;              // 소환 위치

    private void Awake()
    {
        //Debug.Log( GetComponentsInChildren<RectTransform>().Length);
        spawnPoint = GetComponentsInChildren<RectTransform>();
    }

    public void Spawn(int num)
    {
        // 카드 비용을 float 형으로 변환
        if(float.TryParse(GameManager.instance.AllCharacter_List[GameManager.instance.partySetCardIndex[num]].Cost, out float cardCost))
        {
            // 소환 가능한 자원이 있을 경우에만 소환 가능
            if (FightManager.fightManager.curResourceMoney < cardCost) { return; }

            else if (FightManager.fightManager.curResourceMoney >= cardCost)
            {
                // 비용 지불
                FightManager.fightManager.curResourceMoney -= cardCost;

                // 소환
                GameObject character = FightManager.fightManager.characterPoolManager.Get(num);
                character.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length - 1)].transform.position;
            }
        }
    }
}
