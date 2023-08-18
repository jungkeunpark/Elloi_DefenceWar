using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageWinManager : MonoBehaviour
{
    // 스테이지 이름
    string curSceneName;

    // 스테이지 index (게임매니저가 들고 있음)

    // 스테이지 win 매니저가 들고 있을 변수들
    public TextMeshProUGUI getExpText;  // 획득 경험치
    public TextMeshProUGUI curExpText;  // 현재 경험치

    // 보상
    public GameObject rewardGrid;           // 리워드 그리드
    public GameObject[] rewards;            // 획득가능한 보상
    public TextMeshProUGUI[] getCoinTexts;  // 획득 코인
    public int[] coinAmount = new int[3];   // 획득한 코인 수량
    public float expAmount;                 // 획득한 경험치 수량

    // 이미지
    public Image curExpBar;     // 현재 경험치 바

    // 버튼들
    public Button retryButton;  // 재시작 버튼
    public Button homeButton;   // 되돌아가기 버튼

    // 레벨업 변수
    public float needLevelUpExp = 500f;  // 레벨업 까지 필요한 경험치
    public float curLevelExp = 100f;     // 현재 경험치

    private void OnEnable()
    {
        SetReward();
    }

    private void Update()
    {
        // 현재 씬 이름
        curSceneName = SceneManager.GetActiveScene().name;

        // { 텍스트 출력
        getExpText.text = string.Format("{0}", expAmount);
        curExpText.text = string.Format("{0} + {1} / {2}", curLevelExp, expAmount, needLevelUpExp);
        getCoinTexts[0].text = string.Format("{0}", coinAmount[0]);
        getCoinTexts[1].text = string.Format("{0}", coinAmount[1]);
        getCoinTexts[2].text = string.Format("{0}", coinAmount[2]);
        // } 텍스트 출력

        // 경험치 바 채우기
        curExpBar.fillAmount = (curLevelExp + expAmount) / needLevelUpExp;
    }

    // 보상을 정하는 함수
    public void SetReward()
    {
        // 경험치
        expAmount = Random.Range(20f, 40f);

        // 코인 보상 정하기
        for (int i = 0; i < rewards.Length; i++)
        {
            // 1개는 확정 보상
            if (i == 0)
            {
                rewards[i].SetActive(true);

                // 코인 랜덤 획득
                coinAmount[i] = Random.Range(50, 200);
                GameManager.instance.playerGold += coinAmount[i];
            }

            // 나머지 2개는 30% 확률로 등장
            else
            {
                int ranGet = Random.Range(0, 3);
                if (ranGet == 0)
                {
                    rewards[i].SetActive(true);

                    // 코인 랜덤 획득
                    coinAmount[i] = Random.Range(50, 200);
                    GameManager.instance.playerGold += coinAmount[i];
                }
                else { rewards[i].SetActive(false); }
            }
        }
    }

    // 재시작 버튼 클릭 시
    public void ClickRetryButton()
    {
        SceneManager.LoadScene(curSceneName);
    }

    // 홈 버튼 클릭 시
    public void ClickHomeButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
