using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
// using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    private RectTransform[] spawnPoint;         // 소환 위치

    public Image[] coolTimeGauges;     // 쿨타임 게이지

    // 쿨타임이 다 찼는지 체크
    public bool[] spawnAble = new bool[6] { true, true, true, true, true, true };

    // 비용
    public float[] costs = new float[6];             

    // 쿨타임 타이머
    public float[] timers = new float[6];

    // 해당 카드의 쿨타임
    public float[] coolTimes = new float[6];
    

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<RectTransform>();

        for (int i = 0; i < coolTimeGauges.Length; i++)
        {
            coolTimeGauges[i].fillAmount = 0f;
        }
    }

    private void Update()
    {
        // 1번 쿹타임
        if (spawnAble[0] == false)
        {
            timers[0] += Time.deltaTime;

            if (timers[0] >= coolTimes[0])
            {
                spawnAble[0] = true;
            }
            else if(timers[0] < coolTimes[0])
            {
                coolTimeGauges[0].fillAmount = 1 - (timers[0] / coolTimes[0]);
            }
        }

        // 2번 쿨타임
        if (spawnAble[1] == false)
        {
            timers[1] += Time.deltaTime;

            if (timers[1] >= coolTimes[1])
            {
                spawnAble[1] = true;
            }
            else if (timers[1] < coolTimes[1])
            {
                coolTimeGauges[1].fillAmount = 1 - (timers[1] / coolTimes[1]);
            }
        }

        // 3번 쿨타임
        if (spawnAble[2] == false)
        {
            timers[2] += Time.deltaTime;

            if (timers[2] >= coolTimes[2])
            {
                spawnAble[2] = true;
            }
            else if (timers[2] < coolTimes[2])
            {
                coolTimeGauges[2].fillAmount = 1 - (timers[2] / coolTimes[2]);
            }
        }

        // 4번 쿨타임
        if (spawnAble[3] == false)
        {
            timers[3] += Time.deltaTime;

            if (timers[3] >= coolTimes[3])
            {
                spawnAble[3] = true;
            }
            else if (timers[3] < coolTimes[3])
            {
                coolTimeGauges[3].fillAmount = 1 - (timers[3] / coolTimes[3]);
            }
        }

        // 5번 쿨타임
        if (spawnAble[4] == false)
        {
            timers[4] += Time.deltaTime;

            if (timers[4] >= coolTimes[4])
            {
                spawnAble[4] = true;
            }
            else if (timers[4] < coolTimes[4])
            {
                coolTimeGauges[4].fillAmount = 1 - (timers[4] / coolTimes[4]);
            }
        }

        // 6번 쿨타임
        if (spawnAble[5] == false)
        {
            timers[5] += Time.deltaTime;

            if (timers[5] >= coolTimes[5])
            {
                spawnAble[5] = true;
            }
            else if (timers[5] < coolTimes[5])
            {
                coolTimeGauges[5].fillAmount = 1 - (timers[5] / coolTimes[5]);
            }
        }
    }

    public void Spawn(int num)
    {
        // 스폰 쿨타임 가져오기
        if (float.TryParse(GameManager.instance.AllCharacter_List[GameManager.instance.partySetCardIndex[num]].ResponeCoolTime, out float _spawnCoolTime))
        {
            coolTimes[num] = _spawnCoolTime;
        }

        // 카드 비용 가져오기
        if (float.TryParse(GameManager.instance.AllCharacter_List[GameManager.instance.partySetCardIndex[num]].Cost, out float _cost))
        {
            costs[num] = _cost;
        }

        // 소환 불가능
        if (spawnAble[num] == false || FightManager.fightManager.curResourceMoney < costs[num]) { return; }

        // 소환 가능
        else if (spawnAble[num] == true && FightManager.fightManager.curResourceMoney >= costs[num])
        {
            // 비용 지불
            FightManager.fightManager.curResourceMoney -= costs[num];

            // 소환
            GameObject character = FightManager.fightManager.characterPoolManager.Get(num);
            character.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length - 1)].transform.position;

            // 타이머 초기화
            coolTimeGauges[num].fillAmount = 1.0f;
            spawnAble[num] = false;
            timers[num] = 0f;
        }
    }
}
