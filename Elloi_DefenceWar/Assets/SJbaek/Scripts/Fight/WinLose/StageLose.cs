using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageLose : MonoBehaviour
{
    // ������ UI��
    public Image loseImage;
    public TextMeshProUGUI loseText;

    // Ȱ��ȭ �Ǿ����� ����
    public bool isAble = false;

    // �̹���, �ؽ�Ʈ RectTransform
    private RectTransform imageRect;
    private RectTransform textRect;

    // ���� �� �̸�
    string curSceneName;

    private void Awake()
    {
        curSceneName = SceneManager.GetActiveScene().name;
        imageRect = loseImage.GetComponent<RectTransform>();
        textRect = loseText.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        isAble = true;
    }

    private void OnDisable()
    {
        isAble = false;
    }

    private void Update()
    {
        if (!isAble) { return; }

        // Ȱ��ȭ�� �Ǹ� UI�� 0�� ��ġ���� ���� �����ɴϴ�.
        else if(isAble)
        {
            StartCoroutine(MoveImageUI());
            StartCoroutine(MoveTextUI());
        }
    }

    IEnumerator MoveImageUI()
    {
        // �̹����� y���� 0���� ū ���� �ݺ�
        while(imageRect.anchoredPosition.y > 0)
        {
            // y���� 1�� ���ҽ�Ŵ
            Vector2 _newPosition = imageRect.anchoredPosition;
            _newPosition.y -= 1;
            imageRect.anchoredPosition = _newPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator MoveTextUI()
    {
        // �ؽ�Ʈ�� y���� 0���� ū ���� �ݺ�
        while (textRect.anchoredPosition.y > 0)
        {
            // y���� 1�� ���ҽ�Ŵ
            Vector2 _newPosition = textRect.anchoredPosition;
            _newPosition.y -= 0.5f;
            textRect.anchoredPosition = _newPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }

    // ����� ��ư Ŭ�� ��
    public void ClickRetryButton()
    {
        // ȿ���� ���
        SoundManager.soundManager.PlaySE("ReturnStageSelect");

        SceneManager.LoadScene(curSceneName);
    }

    // Ȩ ��ư Ŭ�� ��
    public void ClickHomeButton()
    {
        // ȿ���� ���
        SoundManager.soundManager.PlaySE("ReturnStageSelect");

        SceneManager.LoadScene("StageSelectScene");
    }
}
