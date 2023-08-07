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
        // ù Ŭ���ΰ�?
        if (partySetManager.isPartyCardClicked == false && partySetCardNum == partySetManager.partyCardIndex)
        {
            partySetManager.isPartyCardClicked = true;

            // ������ ī�� �ε��� ��ȣ
            partySetManager.partyCardIndex = partySetCardNum;
        }

        // ù Ŭ���̸鼭 


        // ù Ŭ���� �ƴϸ鼭 �ٸ� ī�带 �����ߴ°�?
        else if (partySetManager.isPartyCardClicked == true && partySetCardNum != partySetManager.partyCardIndex)
        {

        }


        if(partySetManager.isPartyCardClicked == true)
        {
            // ��� ī���� 0�� �ڽĿ�����Ʈ ���� (Ŭ�� ����Ʈ)
            for (int i = 0; i < partySetCards.Length; i++)
            {
                partySetCards[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            // ���õ� ī���� 0�� �ڽĿ�����Ʈ�� Ȱ��ȭ
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);
        }


    }
}
