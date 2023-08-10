using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageWinManager : MonoBehaviour
{
    // �������� win ĵ����
    public Canvas stageWinCanvas;
    public Canvas[] stagesCanvas;

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

    // ����� ��ư Ŭ�� ��
    public void ClickRetryButton()
    {
        // �¸� UIĵ���� ��Ȱ��ȭ
        stageWinCanvas.gameObject.SetActive(false);

        // ������������ ĵ���� Ȱ��ȭ
        stagesCanvas[GameManager.instance.nowStageIndex].gameObject.SetActive(true);
    }

    // Ȩ ��ư Ŭ�� ��
    public void ClickHomeButton()
    {
        // �¸� UIĵ���� ��Ȱ��ȭ
        stageWinCanvas.gameObject.SetActive(false);
    }

    // Update()
    private void Update()
    {
        // { �ؽ�Ʈ ���
        getExpText.text = string.Format("{0}", expAmount);
        curExpText.text = string.Format("{0} / {1}", expAmount, needLevelUpExp);
        getCoinText.text = string.Format("{0}", coinAmount);
        // } �ؽ�Ʈ ���

        // ����ġ �� ä���
        curExpBar.fillAmount = curLevelExp / needLevelUpExp;
    }

    // Ȱ��ȭ �� ȹ���� �� �ִ� ���� + ���� ���ϱ�
    private void OnEnable()
    {
        // ����ġ ����
        curLevelExp += curLevelExp;
    }

    // ��Ȱ��ȭ �� ������ �ʱ�ȭ
    private void OnDisable()
    {
        coinAmount = 0;
        expAmount = 0;
    }
}
