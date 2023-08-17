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
    public TextMeshProUGUI getCoinText; // ȹ�� ����

    // ����
    public GameObject rewardGrid;   // ������ �׸���
    public GameObject[] rewards;    // ȹ�氡���� ����
    public int coinAmount;          // ȹ���� ���� ����
    public float expAmount;           // ȹ���� ����ġ ����

    // �̹���
    public Image curExpBar;     // ���� ����ġ ��

    // ��ư��
    public Button retryButton;  // ����� ��ư
    public Button homeButton;   // �ǵ��ư��� ��ư

    // �׽�Ʈ ����
    public float needLevelUpExp = 500f;  // ������ ���� �ʿ��� ����ġ
    public float curLevelExp = 100f;     // ���� ����ġ

    private void Awake()
    {
        // ���� �� �̸�
        curSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        // { �ؽ�Ʈ ���
        getExpText.text = string.Format("{0}", expAmount);
        curExpText.text = string.Format("{0} / {1}", expAmount, needLevelUpExp);
        getCoinText.text = string.Format("{0}", coinAmount);
        // } �ؽ�Ʈ ���

        // ����ġ �� ä���
        curExpBar.fillAmount = curLevelExp / needLevelUpExp;
    }       // Update()

    // ������ ���ϴ� �Լ�
    public void SetReward()
    {

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
