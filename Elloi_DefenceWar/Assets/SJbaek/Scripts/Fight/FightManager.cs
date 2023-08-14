using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class FightManager : MonoBehaviour
{
    // ��ũ��Ʈ
    public static FightManager fightManager;
    public CharacterPoolManager characterPoolManager;
    public EnemyPoolManager enemyPoolManager;

    // ĵ������
    public Canvas gamePauseCanvas;  // ���� ����

    // ���� ��������
    public int stage = 0;

    // ������������ �޶��� ������
    public List<int> maxResourceMoneys;  // �÷��̾� �ڿ�
    public List<int> maxPlayerTowerHps;  // �÷��̾� Ÿ�� ü��
    public List<int> maxEnemyTowerHps;   // �� Ÿ�� ü��

    public int maxPlayerTowerHp;    // �ִ� �÷��̾� Ÿ�� ü��
    public int curPlayerTowerHp;    // ���� �÷��̾� Ÿ�� ü��
    public int maxEnemyTowerHp;     // �ִ� �� Ÿ�� ü��
    public int curEnemyTowerHp;     // ���� �� Ÿ�� ü��

    // Ÿ�� ü�¹� �̹���
    public Image playerTowerHpBar;
    public Image enemyTowerHpBar;

    // �÷��̾� �ڿ�
    public float curResourceMoney;          // ���� ���� �ڿ�
    public List<int> needLevelUpResourceMoney;  // �������� �ʿ��� �ڿ�                  // �̰� �ƹ��͵� �ȳ־��µ�?
    public List<int> resourceIncrement;         // �ڿ� ȸ�� ������
    public int maxResourceLevel = 9;        // �ִ� �ڿ� ����
    public int curResourceLevel = 0;        // ���� �ڿ� ����

    // ��ų ��Ÿ��
    public List<int> skillCoolTime;

    // ĳ���� ī�� �̹�����
    public Image[] selectedCharacters; 
    public Sprite[] characterCards;
    public int characterCardIndex;

    // ĳ���� ī�� cost �ؽ�Ʈ��
    public TextMeshProUGUI[] cardCostTexts;
    // ���� ������
    public bool isDoublespeed = false; // ���� 2��� ����

    // �ؽ�Ʈ 
    public TextMeshProUGUI playerTowerHp;   // �÷��̾� Ÿ�� ü��
    public TextMeshProUGUI EnemyTowerHp;    // �� Ÿ�� ü��

    // �������� �ʿ��� �ڿ� �ؽ�Ʈ
    public TextMeshProUGUI resource;
    public TextMeshProUGUI needLevelUpResourceMoneyText;
    public Button levelUpButton;        // ������ ��ư

    // �������� ������Ʈ
    public GameObject doubleSpeedButton;
    public GameObject auto;

    // ������ ���� �ؽ�Ʈ
    public TextMeshProUGUI doubleSpeedCount;
    public TextMeshProUGUI autoCount;

    private void Awake()
    {
        fightManager = this;

        // Ÿ�� ü�� �ʱ�ȭ
        maxPlayerTowerHp = maxPlayerTowerHps[stage];
        maxEnemyTowerHp = maxEnemyTowerHps[stage];

        curPlayerTowerHp = maxPlayerTowerHp;
        curEnemyTowerHp = maxEnemyTowerHp;

        // ü�¹� �ʱ�ȭ
        playerTowerHpBar.fillAmount = 1f;
        enemyTowerHpBar.fillAmount = 1f;
    }

    private void Start()
    {
        // ĳ���� ī�� ����
        for (int index = 0; index < selectedCharacters.Length; index++)
        {
            if (GameManager.instance.partySetCardIndex[index] != -1)
            {
                // ĳ���� ī���� �̹����� ����ؽ�Ʈ ����
                selectedCharacters[index].sprite = characterCards[index];
                selectedCharacters[index].SetNativeSize();
                selectedCharacters[index].transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                cardCostTexts[index].text = GameManager.instance.MyCharacter_List[GameManager.instance.partySetCardIndex[index]].Cost;
            }

            else { return; }
        }
    }

    // ������Ʈ
    private void Update()
    {
        // { �ؽ�Ʈ ���
        playerTowerHp.text = string.Format("{0} / {1}", curPlayerTowerHp, maxPlayerTowerHps[stage]);
        EnemyTowerHp.text = string.Format("{0} / {1}", curEnemyTowerHp, maxEnemyTowerHps[stage]);
        doubleSpeedCount.text = string.Format("{0}", GameManager.instance.doubleSpeedCount);
        autoCount.text = string.Format("{0}", GameManager.instance.autoItemCount);
        
        // �ڿ� �������� �ʿ��� �ڿ�
        // �ִ� ���� �̶��?
        if(curResourceLevel >= maxResourceLevel)
        {
            // ��ư ��Ȱ��ȭ
            levelUpButton.interactable = false;
            needLevelUpResourceMoneyText.text = string.Format("MAX");
        }

        // �ִ� ������ �ƴ϶��
        else
        {
            // ��ư Ȱ��ȭ 
            levelUpButton.interactable = true;
            needLevelUpResourceMoneyText.text = string.Format("{0}", needLevelUpResourceMoney[curResourceLevel]);
        }
        // } �ؽ�Ʈ ���

        // { �ڿ� ��� �÷��ֱ�
        curResourceMoney += Time.deltaTime * resourceIncrement[curResourceLevel];

        if (curResourceMoney > maxResourceMoneys[curResourceLevel])
        {
            curResourceMoney = maxResourceMoneys[curResourceLevel];
        }

        resource.text = string.Format("{0} / {1}", (int)curResourceMoney, maxResourceMoneys[curResourceLevel]);
        // } �ڿ� ��� �÷��ֱ�

        // Ÿ�� ü�¹� ������Ʈ
        playerTowerHpBar.fillAmount = (float)curPlayerTowerHp / (float)maxPlayerTowerHp;
        enemyTowerHpBar.fillAmount = (float)curEnemyTowerHp / (float)maxEnemyTowerHp;

    }   // end ������Ʈ

    //// Ȱ��ȭ �Ǹ�
    //public void OnEnable()
    //{
    //    // Ÿ�� ü�� �ʱ�ȭ
    //    curPlayerTowerHp = maxPlayerTowerHp[stage];
    //    curEnemyTowerHp = maxEnemyTowerHp[stage];
    //}

    // ������ ����ϴ� �Լ�
    public void DoubleSpeed()
    {
        // ����ϱ� & ����Ʈ Ű��
        if (isDoublespeed == false)
        {
            Time.timeScale = 2.0f;
            isDoublespeed = true;
            doubleSpeedButton.transform.GetChild(0).gameObject.SetActive(true);
        }

        else if(isDoublespeed == true)
        {
            Time.timeScale = 1.0f;
            isDoublespeed = false;
            doubleSpeedButton.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // �ڿ� ������ �ϴ� �Լ�
    public void ResourceLevelUp()
    {
        // ���� ���� �ڿ��� �������� �ʿ��� �ڿ����� ���ٸ� ����
        if(curResourceMoney < needLevelUpResourceMoney[curResourceLevel]) { return; }

        // ���� ���� �ڿ��� �������� �ʿ��� �ڿ����� ���ٸ�
        else if(curResourceMoney >= needLevelUpResourceMoney[curResourceLevel])
        {
            // �ִ� ���� �̶��?
            if(curResourceLevel >= maxResourceLevel)
            {
                // ���� ����
                curResourceLevel = maxResourceLevel;
            }

            // �ִ� ������ �ƴ϶��
            else
            {
                // ���� ���� �� - ���ֱ�
                curResourceMoney -= needLevelUpResourceMoney[curResourceLevel];

                // ���� ��
                curResourceLevel++;
            }
        }
    }       // end �ڿ� ������ �ϴ� �Լ�

    // ���� ���� ��ư Ŭ�� ��
    public void ClickGamePause()
    {
        // ���� ���� UI Ȱ��ȭ
        gamePauseCanvas.gameObject.SetActive(true);
        // ���� �ð� 0���� ����
        Time.timeScale = 0;
    }

    // ���� �й� ��ư Ŭ����
    public void ClickGameEnd()
    {
        // ���� ���� UI ��Ȱ��ȭ

        // ���� �й� UI Ȱ��ȭ

        // ���� �Ŵ��� ����

        // ���� �ð� 1���� ����
    }

    // ���� ��� ��ư Ŭ����
    public void ClickGameResume()
    {
        // ���� ���� UI ��Ȱ��ȭ
        gamePauseCanvas.gameObject.SetActive(false);

        // ���� �ð� 1���� ����
        Time.timeScale = 1;
    }
}
