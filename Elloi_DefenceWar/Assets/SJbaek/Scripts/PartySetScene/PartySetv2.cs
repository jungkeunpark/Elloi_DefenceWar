using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySetv2 : MonoBehaviour
{
    public PartySetManager partySetManager;

    public GameObject[] partySetCards;
    public GameObject selectedCard = null;
    public int selectedCardNum;

    public void TapClick(int partySetCardNum)
    {
        // 첫 클릭인가?
        if (partySetManager.isPartyCardClicked == false && partySetCardNum == partySetManager.partyCardIndex)
        {
            partySetManager.isPartyCardClicked = true;

            // 선택한 카드 인덱스 번호
            partySetManager.partyCardIndex = partySetCardNum;
        }

        // 첫 클릭이면서 


        // 첫 클릭이 아니면서 다른 카드를 선택했는가?
        else if (partySetManager.isPartyCardClicked == true && partySetCardNum != partySetManager.partyCardIndex)
        {

        }


        if(partySetManager.isPartyCardClicked == true)
        {
            // 모든 카드의 0번 자식오브젝트 끄기 (클릭 이펙트)
            for (int i = 0; i < partySetCards.Length; i++)
            {
                partySetCards[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            // 선택된 카드의 0번 자식오브젝트만 활성화
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);
        }


    }
}
