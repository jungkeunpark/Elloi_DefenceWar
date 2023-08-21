using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class Percantages : MonoBehaviour
{
    public string externalLinkURL = "https://docs.google.com/spreadsheets/d/11nahBtho4W3iyIgJIoAgaEPiuvXMnxJK7lNiK_QU1lY/edit#gid=0";
    // Start is called before the first frame update
    public void Start()
    {
        Button button = GetComponent<Button>(); // 현재 GameObject에 연결된 Button 컴포넌트 가져오기
        if (button != null)
        {
            button.onClick.AddListener(OpenLink); // 버튼 클릭 이벤트에 OpenLink 메서드 추가
        }
    }

    private void OpenLink()
    {
        Application.OpenURL(externalLinkURL); // 외부 링크 열기
    }
}
