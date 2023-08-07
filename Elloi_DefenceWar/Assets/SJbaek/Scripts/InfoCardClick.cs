using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoCardClick : MonoBehaviour, IPointerClickHandler
{
    private int myIndex;

    //private void OnMouseDown()
    //{
    //    Debug.Log("날 찍음");
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("날 찍음");

        // 해당 오브젝트의 순위를 가져옵니다.
        myIndex = transform.GetSiblingIndex();

        // 자식오브젝트가 있다면 게임매니저의 데이터 순번으로 넘김 (즉, 생성된 카드가 있다면)
        if(transform.childCount != 0)
        {
            //GameManager.instance.dataIndex = myIndex;
        }
    }
}
