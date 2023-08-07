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
        // 내가 클릭한 오브젝트의 태그 보기
        Debug.Log(gameObject.transform.tag);

        // PartySet 태그를 클릭했다면
        if (gameObject.transform.tag.Equals("PartySet"))
        {
            PartySet currPartySet = gameObject.GetComponent<PartySet>();

            // PartySet이 이미 차있다면
            if (currPartySet.isFill)
            {
                currPartySet.CleanImage();
            }

            // PartySet이 차있지 않다면, selectPartySet으로 선택한다.
            else
            {
                GameManager.instance.selectPartySet = gameObject.GetComponent<PartySet>();
            }
        }

        // 활성화 된 카드를 선택했다면
        if(gameObject.transform.tag.Equals("PartyCard") && transform.childCount != 0)
        {
            // PartySet이 차있지 않다면, 아무일도 일어나지 않는다.
            if (GameManager.instance.selectPartySet == null)
            {
                //nothing
            }

            // PartySet이 차있다면,
            else
            {
                GameManager.instance.selectPartySet.SetImage(cardData.characterImage.sprite);
            }
        }
    }
}
