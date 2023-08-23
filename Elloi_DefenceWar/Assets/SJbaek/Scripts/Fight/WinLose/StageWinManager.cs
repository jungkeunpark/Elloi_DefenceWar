using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageWinManager : MonoBehaviour
{
    // �������� �̸�
    string curSceneName;

    // �������� index (���ӸŴ����� ��� ����)

    // �������� win �Ŵ����� ��� ���� ������
    public TextMeshProUGUI getExpText;  // ȹ�� ����ġ
    public TextMeshProUGUI curExpText;  // ���� ����ġ

    // ����
    public GameObject rewardGrid;           // ������ �׸���
    public GameObject[] rewards;            // ȹ�氡���� ����
    public TextMeshProUGUI[] getCoinTexts;  // ȹ�� ����
    public int[] coinAmount = new int[3];   // ȹ���� ���� ����
    public int expAmount;                 // ȹ���� ����ġ ����

    // ���� ����
    private int[] getCoinMin = new int[16] { 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180};
    private int[] getCoinMax = new int[16] { 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280 };

    private int[] getExpMin = new int[16] { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85 };
    private int[] getExpMax = new int[16] { 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105 };

    // �̹���
    public Image curExpBar;     // ���� ����ġ ��

    // ��ư��
    public Button retryButton;  // ����� ��ư
    public Button homeButton;   // �ǵ��ư��� ��ư

    // ������ ����
    public int needLevelUpExp = 500;  // ������ ���� �ʿ��� ����ġ
    // public float curLevelExp;     // ���� ����ġ ( ���� �Ŵ����� ���� )

    private void OnEnable()
    {
        SetReward();
    }

    private void Start()
    {
        // ���� �� �̸�
        curSceneName = SceneManager.GetActiveScene().name;

        // { �ؽ�Ʈ ���
        getExpText.text = string.Format("{0}", expAmount);
        curExpText.text = string.Format("{0} / {1}", GameManager.instance.curExp, GameManager.instance.needLevelUpExp[GameManager.instance.playerLevel]);
        getCoinTexts[0].text = string.Format("{0}", coinAmount[0]);
        getCoinTexts[1].text = string.Format("{0}", coinAmount[1]);
        getCoinTexts[2].text = string.Format("{0}", coinAmount[2]);
        // } �ؽ�Ʈ ���

        // ����ġ �� ä���
        curExpBar.fillAmount = (float)GameManager.instance.curExp / (float)GameManager.instance.needLevelUpExp[GameManager.instance.playerLevel];

        // { �������� Ŭ���� üũ
        // �ߺ�üũ
        int _ClearCheck = 0;

        foreach (int index in GameManager.instance.clearStageIndex)
        {
            if (index == FightManager.fightManager.stage) { _ClearCheck++; }
            else { continue; }
        }

        // �ߺ��� ���ٸ� stageŬ��� ��ȣ �߰��ϱ�
        if (_ClearCheck == 0)
        {
            GameManager.instance.clearStageIndex.Add(FightManager.fightManager.stage);
        }
        else { return; }
        // } �������� Ŭ���� üũ
    }

    // ������ ���ϴ� �Լ�
    public void SetReward()
    {
        // ����ġ
        expAmount = Random.Range(getExpMin[FightManager.fightManager.stage], getExpMax[FightManager.fightManager.stage]);
        GameManager.instance.curExp += expAmount;

        // ������ ���� ����?
        if(GameManager.instance.curExp >= GameManager.instance.needLevelUpExp[GameManager.instance.playerLevel])
        {
            GameManager.instance.playerLevel++; // ������
            GameManager.instance.curExp = 0;    // ����ġ �ʱ�ȭ
        }

        // ���� ���� ���ϱ�
        for (int i = 0; i < rewards.Length; i++)
        {
            // 1���� Ȯ�� ����
            if (i == 0)
            {
                rewards[i].SetActive(true);

                // ���� ���� ȹ��
                coinAmount[i] = Random.Range(getCoinMin[FightManager.fightManager.stage], getCoinMax[FightManager.fightManager.stage]);
                GameManager.instance.playerGold += coinAmount[i];
            }

            // ������ 2���� 30% Ȯ���� ����
            else
            {
                int ranGet = Random.Range(0, 3);
                if (ranGet == 0)
                {
                    rewards[i].SetActive(true);

                    // ���� ���� ȹ��
                    coinAmount[i] = Random.Range(getCoinMin[FightManager.fightManager.stage], getCoinMax[FightManager.fightManager.stage]);
                    GameManager.instance.playerGold += coinAmount[i];
                }
                else { rewards[i].SetActive(false); }
            }
        }
    }

    // ����� ��ư Ŭ�� ��
    public void ClickRetryButton()
    {
        SceneManager.LoadScene(curSceneName);
    }

    // Ȩ ��ư Ŭ�� ��
    public void ClickHomeButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
