using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class FightManager : MonoBehaviour
{
    // 스크립트
    public static FightManager fightManager;
    public CharacterPoolManager characterPoolManager;
    public EnemyPoolManager enemyPoolManager;

    // 캔버스들 (게임오브젝트로 빼서 변경함) sortingRayer...
    public Canvas gamePauseCanvas;  // 게임 중지 캔버스
    public Canvas gameWinCanvas;    // 게임 승리 캔버스
    public Canvas gameLoseCanvas;   // 게임 패배 캔버스

    // 현재 스테이지
    public int stage = 0;

    // 스테이지마다 달라질 변수들
    public List<int> maxResourceMoneys;  // 플레이어 자원
    public List<int> maxPlayerTowerHps;  // 플레이어 타워 체력
    public List<int> maxEnemyTowerHps;   // 적 타워 체력

    public int maxPlayerTowerHp;    // 최대 플레이어 타워 체력
    public int curPlayerTowerHp;    // 현재 플레이어 타워 체력
    public int maxEnemyTowerHp;     // 최대 적 타워 체력
    public int curEnemyTowerHp;     // 현재 적 타워 체력

    // 타워 체력바 이미지
    public Image playerTowerHpBar;
    public Image enemyTowerHpBar;

    // 플레이어 자원
    public float curResourceMoney;          // 현재 가진 자원
    public List<int> needLevelUpResourceMoney;  // 레벨업에 필요한 자원                  // 이거 아무것도 안넣었는데?
    public List<int> resourceIncrement;         // 자원 회복 증가량
    public int maxResourceLevel = 9;        // 최대 자원 레벨
    public int curResourceLevel = 0;        // 현재 자원 레벨

    // 스킬 쿨타임
    public List<int> skillCoolTime;

    // 캐릭터 카드
    public GameObject[] cards;
    public Image[] selectedCharacters; 
    public int characterCardIndex;

    // 캐릭터 카드 cost 텍스트들
    public TextMeshProUGUI[] cardCostTexts;

    // 게임 아이템
    public bool isDoubleSpeed = false; // 게임 2배속 여부
    public bool useDoubleSpeed = false; // 아이템 사용 여부

    // 텍스트 
    public TextMeshProUGUI playerTowerHp;   // 플레이어 타워 체력
    public TextMeshProUGUI EnemyTowerHp;    // 적 타워 체력

    // 레벨업에 필요한 자원 텍스트
    public TextMeshProUGUI resource;
    public TextMeshProUGUI needLevelUpResourceMoneyText;
    public Button levelUpButton;        // 레벨업 버튼

    // 사용아이템 오브젝트
    public GameObject doubleSpeedButton;
    public GameObject auto;

    // 아이템 갯수 텍스트
    public TextMeshProUGUI doubleSpeedCount;
    public TextMeshProUGUI autoCount;

    private void Awake()
    {
        fightManager = this;

        // 게임 시간 초기화
        Time.timeScale = 1.0f;

        // 타워 체력 초기화
        maxPlayerTowerHp = maxPlayerTowerHps[stage];
        maxEnemyTowerHp = maxEnemyTowerHps[stage];

        curPlayerTowerHp = maxPlayerTowerHp;
        curEnemyTowerHp = maxEnemyTowerHp;

        // 체력바 초기화
        playerTowerHpBar.fillAmount = 1f;
        enemyTowerHpBar.fillAmount = 1f;
    }

    private void Start()
    {
        // 캐릭터 카드 셋팅
        for (int index = 0; index < selectedCharacters.Length; index++)
        {
            // 파티 셋팅이 되어 있지 않다면 비활성화 (그리드 되어있음)
            if(GameManager.instance.partySetCardIndex[index] == -1)
            {
                cards[index].gameObject.SetActive(false);
            }

            // 파티 셋팅이 되어있다면...
            else if (GameManager.instance.partySetCardIndex[index] != -1)
            {
                // 캐릭터 카드의 이미지와 비용텍스트 변경
                Sprite tempSprite = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].transform.GetChild(2).GetComponent<Image>().sprite;
                selectedCharacters[index].sprite = tempSprite;
                selectedCharacters[index].SetNativeSize();
                selectedCharacters[index].transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                cardCostTexts[index].text = GameManager.instance.AllCharacter_List[GameManager.instance.partySetCardIndex[index]].Cost;
            }

            else { return; }
        }
    }

    // 업데이트
    private void Update()
    {
        // { 텍스트 출력
        playerTowerHp.text = string.Format("{0} / {1}", curPlayerTowerHp, maxPlayerTowerHps[stage]);
        EnemyTowerHp.text = string.Format("{0} / {1}", curEnemyTowerHp, maxEnemyTowerHps[stage]);
        doubleSpeedCount.text = string.Format("{0}", GameManager.instance.doubleSpeedCount);
        autoCount.text = string.Format("{0}", GameManager.instance.autoItemCount);
        
        // 자원 레벨업에 필요한 자원
        // 최대 레벨 이라면?
        if(curResourceLevel >= maxResourceLevel)
        {
            // 버튼 비활성화
            levelUpButton.interactable = false;
            needLevelUpResourceMoneyText.text = string.Format("MAX");
        }

        // 최대 레벨이 아니라면
        else
        {
            // 버튼 활성화 
            levelUpButton.interactable = true;
            needLevelUpResourceMoneyText.text = string.Format("{0}", needLevelUpResourceMoney[curResourceLevel]);
        }
        // } 텍스트 출력

        // { 자원 계속 올려주기
        curResourceMoney += Time.deltaTime * resourceIncrement[curResourceLevel];

        if (curResourceMoney > maxResourceMoneys[curResourceLevel])
        {
            curResourceMoney = maxResourceMoneys[curResourceLevel];
        }

        resource.text = string.Format("{0} / {1}", (int)curResourceMoney, maxResourceMoneys[curResourceLevel]);
        // } 자원 계속 올려주기

        // 타워 체력바 업데이트
        playerTowerHpBar.fillAmount = (float)curPlayerTowerHp / (float)maxPlayerTowerHp;
        enemyTowerHpBar.fillAmount = (float)curEnemyTowerHp / (float)maxEnemyTowerHp;

        // 적 타워 파괴 시
        if(curEnemyTowerHp <= 0)
        {
            DestroyEnemyTower();
        }

        // 플레이어 타워 파괴 시
        if(curPlayerTowerHp <= 0)
        {
            DestoryPlayerTower();
        }

    }       // UpDate()

    // 게임을 배속하는 함수
    public void DoubleSpeed()
    {
        // 배속하기 & 이펙트 키기
        if (isDoubleSpeed == false)
        {
            // 아이템 사용 체크
            if(useDoubleSpeed == true)
            {
                return;
            }
            else if(useDoubleSpeed == false)
            {
                // 아이템 갯수 차감
                useDoubleSpeed = true;
                GameManager.instance.doubleSpeedCount--;
            }

            // 배속 활성화
            Time.timeScale = 2.0f;
            isDoubleSpeed = true;
            doubleSpeedButton.transform.GetChild(0).gameObject.SetActive(true);
        }

        else if(isDoubleSpeed == true)
        {
            // 배속 비활성화
            Time.timeScale = 1.0f;
            isDoubleSpeed = false;
            doubleSpeedButton.transform.GetChild(0).gameObject.SetActive(false);
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
    }       // end 자원 레벨업 하는 함수

    // 게임 정지 버튼 클릭 시
    public void ClickGamePause()
    {
        // 게임 정지 UI 활성화
        gamePauseCanvas.gameObject.SetActive(true);
        // 게임 시간 0으로 변경
        Time.timeScale = 0;
    }

    // 게임 패배 버튼 클릭시
    public void ClickGameEnd()
    {
        // 아이템을 사용했다면 되돌려 줌
        if(useDoubleSpeed == true)
        {
            GameManager.instance.doubleSpeedCount++;
        }

        DestoryPlayerTower();
    }

    // 게임 재게 버튼 클릭시
    public void ClickGameResume()
    {
        // 게임 정지 UI 비활성화
        gamePauseCanvas.gameObject.SetActive(false);

        // 게임 시간 재변경
        if(!isDoubleSpeed)
        {
            Time.timeScale = 1;
        }
        else if(isDoubleSpeed)
        {
            Time.timeScale = 2;
        }
        
    }

    // 적 타워 파괴
    public void DestroyEnemyTower()
    {
        // 게임 시간 0으로 변경
        Time.timeScale = 0;

        // 승리 UI 등장
        gameWinCanvas.gameObject.SetActive(true);
    }

    // 플레이어 타워 파괴
    public void DestoryPlayerTower()
    {
        // 게임 시간 0으로 변경
        Time.timeScale = 0;

        // 패배 UI 등장
        gameLoseCanvas.gameObject.SetActive(true);
    }
}
