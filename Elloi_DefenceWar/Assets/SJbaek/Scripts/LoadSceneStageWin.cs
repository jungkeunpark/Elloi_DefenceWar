using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStageWin : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // ���콺 Ŭ���� ��ǥ�� ��������
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �ش� ��ǥ�� �ִ� ������Ʈ ã��
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit == false || hit.transform.tag.Equals("Stage") == false)
            {
                return;
            }
            else if (hit.transform.tag.Equals("Stage") == true)
            {
                SceneManager.LoadScene("StageWinScene");
            }
            else
            {
                return;
            }
        }
        
    }
}
