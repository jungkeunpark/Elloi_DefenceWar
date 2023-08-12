using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageWinManager : MonoBehaviour
{
    // 스테이지 index (게임매니저가 들고 있음)

    // 스테이지 win 매니저가 들고 있을 변수들
    public TextMeshProUGUI getExpText;  // 획득 경험치
    public TextMeshProUGUI curExpText;  // 현재 경험치
    public TextMeshProUGUI getCoinText; // 획득 코인

    // 보상
    public GameObject rewardGrid;   // 리워드 그리드
    public GameObject[] rewards;    // 획득가능한 보상
    public int coinAmount;          // 획득한 코인 수량
    public float expAmount;           // 획득한 경험치 수량

    // 이미지
    public Image curExpBar;     // 현재 경험치 바

    // 버튼들
    public Button retryButton;  // 재시작 버튼
    public Button homeButton;   // 되돌아가기 버튼

    // 테스트 변수
    public float needLevelUpExp = 500f;  // 레벨업 까지 필요한 경험치
    public float curLevelExp = 100f;     // 현재 경험치

    // 재시작 버튼 클릭 시
    public void ClickRetryButton()
    {
        // ToDo: LoadScene (해당 씬)
    }

    // 홈 버튼 클릭 시
    public void ClickHomeButton()
    {
        // ToDo: LoadScene (스테이지 선택 씬)
    }

    // Update()
    private void Update()
    {
        // { 텍스트 출력
        getExpText.text = string.Format("{0}", expAmount);
        curExpText.text = string.Format("{0} / {1}", expAmount, needLevelUpExp);
        getCoinText.text = string.Format("{0}", coinAmount);
        // } 텍스트 출력

        // 경험치 바 채우기
        curExpBar.fillAmount = curLevelExp / needLevelUpExp;
    }

    // 활성화 시 획득할 수 있는 보상 + 수량 정하기
    private void OnEnable()
    {
        // 경험치 증가
        curLevelExp += curLevelExp;
    }

    // 비활성화 시 데이터 초기화
    private void OnDisable()
    {
        coinAmount = 0;
        expAmount = 0;
    }
}
