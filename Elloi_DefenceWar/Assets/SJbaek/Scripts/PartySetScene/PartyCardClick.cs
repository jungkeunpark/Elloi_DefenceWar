using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartyCardClick : MonoBehaviour, IPointerClickHandler
{
    private int myIndex;
    private Sprite mySprite;
    private CardObjDatas cardData;

    public void Awake()
    {
        mySprite = GetComponent<Sprite>();
        cardData = GetComponentInChildren<CardObjDatas>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // ���� Ŭ���� ������Ʈ�� �±� ����
        Debug.Log(gameObject.transform.tag);

        // PartySet �±׸� Ŭ���ߴٸ�
        if (gameObject.transform.tag.Equals("PartySet"))
        {
            PartySet currPartySet = gameObject.GetComponent<PartySet>();

            // PartySet�� �̹� ���ִٸ�
            if (currPartySet.isFill)
            {
                currPartySet.CleanImage();
            }

            // PartySet�� ������ �ʴٸ�, selectPartySet���� �����Ѵ�.
            else
            {
                GameManager.instance.selectPartySet = gameObject.GetComponent<PartySet>();
            }
        }

        // Ȱ��ȭ �� ī�带 �����ߴٸ�
        if(gameObject.transform.tag.Equals("PartyCard") && transform.childCount != 0)
        {
            // PartySet�� ������ �ʴٸ�, �ƹ��ϵ� �Ͼ�� �ʴ´�.
            if (GameManager.instance.selectPartySet == null)
            {
                //nothing
            }

            // PartySet�� ���ִٸ�,
            else
            {
                GameManager.instance.selectPartySet.SetImage(cardData.characterImage.sprite);
            }
        }
    }
}
