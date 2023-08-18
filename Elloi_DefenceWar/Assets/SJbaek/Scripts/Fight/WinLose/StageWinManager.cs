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
        curExpText.text = string.Format("{0} / {1}", GameManager.instance.exp, needLevelUpExp);
        getCoinTexts[0].text = string.Format("{0}", coinAmount[0]);
        getCoinTexts[1].text = string.Format("{0}", coinAmount[1]);
        getCoinTexts[2].text = string.Format("{0}", coinAmount[2]);
        // } �ؽ�Ʈ ���

        // ����ġ �� ä���
        curExpBar.fillAmount = (float)GameManager.instance.exp / (float)needLevelUpExp;

        //homeButton.onClick.AddListener(() =>
        //{
        //    Debug.Log("Ȩ��ư ����");
        //    SetReward();
        //});
    }

    // ������ ���ϴ� �Լ�
    public void SetReward()
    {
        // ����ġ
        expAmount = Random.Range(20, 40);
        GameManager.instance.exp += expAmount;

        // ���� ���� ���ϱ�
        for (int i = 0; i < rewards.Length; i++)
        {
            // 1���� Ȯ�� ����
            if (i == 0)
            {
                rewards[i].SetActive(true);

                // ���� ���� ȹ��
                coinAmount[i] = Random.Range(50, 200);
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
                    coinAmount[i] = Random.Range(50, 200);
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
