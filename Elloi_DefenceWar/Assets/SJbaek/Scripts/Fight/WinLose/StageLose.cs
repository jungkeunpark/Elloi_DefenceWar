using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageLose : MonoBehaviour
{
    // 움직일 UI들
    public Image loseImage;
    public TextMeshProUGUI loseText;

    // 활성화 되었는지 여부
    public bool isAble = false;

    // 이미지, 텍스트 RectTransform
    private RectTransform imageRect;
    private RectTransform textRect;

    // 현재 씬 이름
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

        // 활성화가 되면 UI가 0의 위치까지 점점 내려옵니다.
        else if(isAble)
        {
            StartCoroutine(MoveImageUI());
            StartCoroutine(MoveTextUI());
        }
    }

    IEnumerator MoveImageUI()
    {
        // 이미지의 y값이 0보다 큰 동안 반복
        while(imageRect.anchoredPosition.y > 0)
        {
            // y값을 1씩 감소시킴
            Vector2 _newPosition = imageRect.anchoredPosition;
            _newPosition.y -= 1;
            imageRect.anchoredPosition = _newPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator MoveTextUI()
    {
        // 텍스트의 y값이 0보다 큰 동안 반복
        while (textRect.anchoredPosition.y > 0)
        {
            // y값을 1씩 감소시킴
            Vector2 _newPosition = textRect.anchoredPosition;
            _newPosition.y -= 0.5f;
            textRect.anchoredPosition = _newPosition;

            yield return new WaitForSeconds(0.1f);
        }
    }

    // 재시작 버튼 클릭 시
    public void ClickRetryButton()
    {
        // 효과음 출력
        SoundManager.soundManager.PlaySE("ReturnStageSelect");

        SceneManager.LoadScene(curSceneName);
    }

    // 홈 버튼 클릭 시
    public void ClickHomeButton()
    {
        // 효과음 출력
        SoundManager.soundManager.PlaySE("ReturnStageSelect");

        SceneManager.LoadScene("StageSelectScene");
    }
}
