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
            // 마우스 클릭한 좌표값 가져오기
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 해당 좌표에 있는 오브젝트 찾기
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
