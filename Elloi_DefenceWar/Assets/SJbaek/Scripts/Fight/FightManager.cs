using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightManager : MonoBehaviour
{
    // 현재 스테이지
    public int stage = 0;

    // 스테이지마다 달라질 변수들
    public List<int> maxResourceMoney;  // 플레이어 자원
    public List<int> maxPlayerTowerHp;  // 플레이어 타워 체력
    public List<int> maxEnemyTowerHp;   // 적 타워 체력

    public int curPlayerTowerHp;    // 현재 플레이어 타워 체력
    public int curEnemyTowerHp;     // 현재 적 타워 체력

    // 플레이어 자원
    public float curResourceMoney;      // 현재 가진 자원
    public List<int> needLevelUpResourceMoney;  // 레벨업에 필요한 자원                  // 이거 아무것도 안넣었는데?
    public List<int> resourceIncrement;         // 자원 회복 증가량
    public int maxResourceLevel = 9;        // 최대 자원 레벨
    public int curResourceLevel = 0;        // 현재 자원 레벨

    // 스킬 쿨타임
    public List<int> skillCoolTime;

    // 캐릭터 카드 이미지들
    public Sprite[] characterCards;
    public int characterCardIndex;

    // 게임 아이템
    public bool isDoublespeed = false; // 게임 2배속 여부

    // 텍스트 
    public TextMeshProUGUI playerTowerHp;   // 플레이어 타워 체력
    public TextMeshProUGUI EnemyTowerHp;    // 적 타워 체력
    // 레벨업에 필요한 자원 텍스트
    public TextMeshProUGUI resource;
    public TextMeshProUGUI needLevelUpResourceMoneyText;
    // 아이템 갯수 텍스트
    public TextMeshProUGUI doubleSpeedCount;
    public TextMeshProUGUI autoCount;

    private void Awake()
    {
        // 타워 체력 초기화
        curPlayerTowerHp = maxPlayerTowerHp[stage];
        curEnemyTowerHp = maxEnemyTowerHp[stage];
    }

    // 업데이트
    private void Update()
    {
        // { 텍스트 출력
        playerTowerHp.text = string.Format("{0} / {1}", curPlayerTowerHp, maxPlayerTowerHp[stage]);
        EnemyTowerHp.text = string.Format("{0} / {1}", curEnemyTowerHp, maxEnemyTowerHp[stage]);
        needLevelUpResourceMoneyText.text = string.Format("{0}", needLevelUpResourceMoney[curResourceLevel]);
        doubleSpeedCount.text = string.Format("{0}", GameManager.instance.doubleSpeedCount);
        autoCount.text = string.Format("{0}", GameManager.instance.autoItemCount);
        // } 텍스트 출력

        // { 자원 계속 올려주기
        curResourceMoney += Time.deltaTime * resourceIncrement[curResourceLevel];

        if (curResourceMoney > maxResourceMoney[curResourceLevel])
        {
            curResourceMoney = maxResourceMoney[curResourceLevel];
        }

        resource.text = string.Format("{0} / {1}", (int)curResourceMoney, maxResourceMoney[curResourceLevel]);
        // } 자원 계속 올려주기
    }

    // 활성화 되면
    public void OnEnable()
    {
        // 타워 체력 초기화
        curPlayerTowerHp = maxPlayerTowerHp[stage];
        curEnemyTowerHp = maxEnemyTowerHp[stage];
    }

    // 게임을 배속하는 함수
    public void DoubleSpeed()
    {
        if(isDoublespeed == false)
        {
            Time.timeScale = 2.0f;
            isDoublespeed = true;
        }

        else if(isDoublespeed == true)
        {
            Time.timeScale = 1.0f;
            isDoublespeed = false;
        }
    }

    // 자원 레벨업 하는 함수
    public void ResourceLevelUp()
    {
        // 현재 가진 자원이 레벨업에 필요한 자원보다 적다면 리턴
        if(curResourceMoney < needLevelUpResourceMoney[curResourceLevel]) { return; }

        // 현재 가진 자원이 레벨업에 필요한 자원보다 많다면
        else if(curResourceMoney >= needLevelUpResourceMoney[curResourceLevel])
        {
            // 최대 레벨 이라면?
            if(curResourceLevel >= maxResourceLevel)
            {
                // 레벨 고정
                curResourceLevel = maxResourceLevel;
            }

            // 최대 레벨이 아니라면
            else
            {
                // 현재 가진 돈 - 해주기
                curResourceMoney -= needLevelUpResourceMoney[curResourceLevel];

                // 레벨 업
                curResourceLevel++;
            }
        }
    }
}
