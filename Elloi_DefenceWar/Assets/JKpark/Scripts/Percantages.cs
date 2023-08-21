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
        Button button = GetComponent<Button>(); // ���� GameObject�� ����� Button ������Ʈ ��������
        if (button != null)
        {
            button.onClick.AddListener(OpenLink); // ��ư Ŭ�� �̺�Ʈ�� OpenLink �޼��� �߰�
        }
    }

    private void OpenLink()
    {
        Application.OpenURL(externalLinkURL); // �ܺ� ��ũ ����
    }
}
