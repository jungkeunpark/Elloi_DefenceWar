using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoCardClick : MonoBehaviour, IPointerClickHandler
{
    private int myIndex;

    //private void OnMouseDown()
    //{
    //    Debug.Log("�� ����");
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�� ����");

        // �ش� ������Ʈ�� ������ �����ɴϴ�.
        myIndex = transform.GetSiblingIndex();

        // �ڽĿ�����Ʈ�� �ִٸ� ���ӸŴ����� ������ �������� �ѱ� (��, ������ ī�尡 �ִٸ�)
        if(transform.childCount != 0)
        {
            //GameManager.instance.dataIndex = myIndex;
        }
    }
}
