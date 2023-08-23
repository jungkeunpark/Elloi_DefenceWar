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

    // ĵ������ (���ӿ�����Ʈ�� ���� ������) sortingRayer...
    public Canvas gamePauseCanvas;  // ���� ���� ĵ����
    public Canvas gameWinCanvas;    // ���� �¸� ĵ����
    public Canvas gameLoseCanvas;   // ���� �й� ĵ����
    public GameObject gameWinManager;   // ���� �¸� �Ŵ���

    // ���� ��������
    public int stage = 0;

    // ������������ �޶��� ������
    public List<int> maxResourceMoneys = new List<int>{ 300, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000};  // �÷��̾� �ڿ�
    public List<int> maxPlayerTowerHps = new List<int> { 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800};  // �÷��̾� Ÿ�� ü��
    public List<int> maxEnemyTowerHps = new List<int> { 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000};   // �� Ÿ�� ü��

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

    // ĳ���� ī��
    public GameObject[] cards;
    public Image[] selectedCharacters; 
    public int characterCardIndex;

    // ĳ���� ī�� cost �ؽ�Ʈ��
    public TextMeshProUGUI[] cardCostTexts;

    // ���� ������
    public bool isDoubleSpeed = false; // ���� 2��� ����
    public bool useDoubleSpeed = false; // ������ ��� ����

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

    // Ȱ��ȭ�� ����
    public List<GameObject> activeEnemys;

    // ȭ�� ������
    public List<GameObject> arrowPrefabs;

    // �� Ÿ�� ��ġ�� ���� ���ӿ�����Ʈ
    public GameObject enemyTower;

    private void Awake()
    {
        fightManager = this;

        // ���� �ð� �ʱ�ȭ
        Time.timeScale = 1.0f;

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
            // ��Ƽ ������ �Ǿ� ���� �ʴٸ� ��Ȱ��ȭ (�׸��� �Ǿ�����)
            if(GameManager.instance.partySetCardIndex[index] == -1)
            {
                cards[index].gameObject.SetActive(false);
            }

            // ��Ƽ ������ �Ǿ��ִٸ�...
            else if (GameManager.instance.partySetCardIndex[index] != -1)
            {
                // ĳ���� ī���� �̹����� ����ؽ�Ʈ ����
                Sprite tempSprite = GameManager.instance.characterCardPrefabs[GameManager.instance.partySetCardIndex[index]].transform.GetChild(2).GetComponent<Image>().sprite;
                selectedCharacters[index].sprite = tempSprite;
                selectedCharacters[index].SetNativeSize();
                selectedCharacters[index].transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                cardCostTexts[index].text = GameManager.instance.AllCharacter_List[GameManager.instance.partySetCardIndex[index]].Cost;
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

        // �� Ÿ�� �ı� ��
        if(curEnemyTowerHp <= 0)
        {
            DestroyEnemyTower();
        }

        // �÷��̾� Ÿ�� �ı� ��
        if(curPlayerTowerHp <= 0)
        {
            DestoryPlayerTower();
        }

    }       // UpDate()

    // ������ ����ϴ� �Լ�
    public void DoubleSpeed()
    {
        // ����ϱ� & ����Ʈ Ű��
        if (isDoubleSpeed == false)
        {
            // ������ ��� üũ
            if(useDoubleSpeed == false)
            {
                // ������ ���� ����
                useDoubleSpeed = true;
                GameManager.instance.doubleSpeedCount--;
            }

            // ��� Ȱ��ȭ
            Time.timeScale = 2.0f;
            isDoubleSpeed = true;
            doubleSpeedButton.transform.GetChild(0).gameObject.SetActive(true);
        }

        else if(isDoubleSpeed == true)
        {
            // ��� ��Ȱ��ȭ
            Time.timeScale = 1.0f;
            isDoubleSpeed = false;
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
        // �������� ����ߴٸ� �ǵ��� ��
        if(useDoubleSpeed == true)
        {
            GameManager.instance.doubleSpeedCount++;
        }

        DestoryPlayerTower();
    }

    // ���� ��� ��ư Ŭ����
    public void ClickGameResume()
    {
        // ���� ���� UI ��Ȱ��ȭ
        gamePauseCanvas.gameObject.SetActive(false);

        // ���� �ð� �纯��
        if(!isDoubleSpeed)
        {
            Time.timeScale = 1;
        }
        else if(isDoubleSpeed)
        {
            Time.timeScale = 2;
        }
        
    }

    // �� Ÿ�� �ı�
    public void DestroyEnemyTower()
    {
        // ���� �ð� 0���� ����
        Time.timeScale = 0;

        // �¸� UI ����
        gameWinCanvas.gameObject.SetActive(true);
        gameWinManager.SetActive(true);
    }

    // �÷��̾� Ÿ�� �ı�
    public void DestoryPlayerTower()
    {
        // ���� �ð� 0���� ����
        Time.timeScale = 0;

        // �й� UI ����
        gameLoseCanvas.gameObject.SetActive(true);
    }
}
