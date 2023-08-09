using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightManager : MonoBehaviour
{
    // ���� ��������
    public int stage = 0;

    // ������������ �޶��� ������
    public List<int> maxResourceMoney;  // �÷��̾� �ڿ�
    public List<int> maxPlayerTowerHp;  // �÷��̾� Ÿ�� ü��
    public List<int> maxEnemyTowerHp;   // �� Ÿ�� ü��

    public int curPlayerTowerHp;    // ���� �÷��̾� Ÿ�� ü��
    public int curEnemyTowerHp;     // ���� �� Ÿ�� ü��

    // �÷��̾� �ڿ�
    public float curResourceMoney;      // ���� ���� �ڿ�
    public List<int> needLevelUpResourceMoney;  // �������� �ʿ��� �ڿ�                  // �̰� �ƹ��͵� �ȳ־��µ�?
    public List<int> resourceIncrement;         // �ڿ� ȸ�� ������
    public int maxResourceLevel = 9;        // �ִ� �ڿ� ����
    public int curResourceLevel = 0;        // ���� �ڿ� ����

    // ��ų ��Ÿ��
    public List<int> skillCoolTime;

    // ĳ���� ī�� �̹�����
    public Sprite[] characterCards;
    public int characterCardIndex;

    // ���� ������
    public bool isDoublespeed = false; // ���� 2��� ����

    // �ؽ�Ʈ 
    public TextMeshProUGUI playerTowerHp;   // �÷��̾� Ÿ�� ü��
    public TextMeshProUGUI EnemyTowerHp;    // �� Ÿ�� ü��
    // �������� �ʿ��� �ڿ� �ؽ�Ʈ
    public TextMeshProUGUI resource;
    public TextMeshProUGUI needLevelUpResourceMoneyText;
    // ������ ���� �ؽ�Ʈ
    public TextMeshProUGUI doubleSpeedCount;
    public TextMeshProUGUI autoCount;

    private void Awake()
    {
        // Ÿ�� ü�� �ʱ�ȭ
        curPlayerTowerHp = maxPlayerTowerHp[stage];
        curEnemyTowerHp = maxEnemyTowerHp[stage];
    }

    // ������Ʈ
    private void Update()
    {
        // { �ؽ�Ʈ ���
        playerTowerHp.text = string.Format("{0} / {1}", curPlayerTowerHp, maxPlayerTowerHp[stage]);
        EnemyTowerHp.text = string.Format("{0} / {1}", curEnemyTowerHp, maxEnemyTowerHp[stage]);
        needLevelUpResourceMoneyText.text = string.Format("{0}", needLevelUpResourceMoney[curResourceLevel]);
        doubleSpeedCount.text = string.Format("{0}", GameManager.instance.doubleSpeedCount);
        autoCount.text = string.Format("{0}", GameManager.instance.autoItemCount);
        // } �ؽ�Ʈ ���

        // { �ڿ� ��� �÷��ֱ�
        curResourceMoney += Time.deltaTime * resourceIncrement[curResourceLevel];

        if (curResourceMoney > maxResourceMoney[curResourceLevel])
        {
            curResourceMoney = maxResourceMoney[curResourceLevel];
        }

        resource.text = string.Format("{0} / {1}", (int)curResourceMoney, maxResourceMoney[curResourceLevel]);
        // } �ڿ� ��� �÷��ֱ�
    }

    // Ȱ��ȭ �Ǹ�
    public void OnEnable()
    {
        // Ÿ�� ü�� �ʱ�ȭ
        curPlayerTowerHp = maxPlayerTowerHp[stage];
        curEnemyTowerHp = maxEnemyTowerHp[stage];
    }

    // ������ ����ϴ� �Լ�
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
    }
}
