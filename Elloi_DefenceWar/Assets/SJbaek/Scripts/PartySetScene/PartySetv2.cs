using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartySetv2 : MonoBehaviour
{
    public PartySetManager partySetManager;

    // (����) ��Ƽ�� ī��
    public GameObject[] partySetCards;
    public int selectedCardNum;

    // (������) �÷��̾� ī��
    public GameObject[] playerCards;
    public GameObject temp_CharacterCard;

    // ��Ƽ�� ī�� ����
    public TextMeshProUGUI[] costs;
    public TextMeshProUGUI[] respons;

    public void Awake()
    {
        partySetManager = gameObject.AddComponent<PartySetManager>();
    }

    // { ��Ƽ�� ī�� Ŭ��
    public void TapClick(int partySetCardNum)
    {
        // ù Ŭ���ΰ�?
        if (partySetManager.isPartyCardClicked == false && partySetManager.partyCardIndex == -1)
        {
            // ���õ� ī���� 0�� �ڽĿ�����Ʈ Ȱ��ȭ
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);

            // Ŭ�� �� üũ
            partySetManager.isPartyCardClicked = true;

            // ������ ī�� �ε��� ��ȣ ����
            partySetManager.partyCardIndex = partySetCardNum;
        }


        // ù Ŭ���� �ƴϸ鼭 �ٸ� ī�带 �����ߴ°�?
        else if (partySetManager.isPartyCardClicked == true && partySetCardNum != partySetManager.partyCardIndex)
        {
            // ��� ī���� 0�� �ڽĿ�����Ʈ ���� (Ŭ�� ����Ʈ)
            for (int i = 0; i < partySetCards.Length; i++)
            {
                partySetCards[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            // ���õ� ī���� 0�� �ڽĿ�����Ʈ�� Ȱ��ȭ
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);

            // ������ ī�� �ε��� ��ȣ ����
            partySetManager.partyCardIndex = partySetCardNum;
        }

        // ù Ŭ���� �ƴϸ鼭 ������ ī�带 �����ߴ°�?
        else if (partySetManager.isPartyCardClicked == true && partySetCardNum == partySetManager.partyCardIndex)
        {
            // ������ ������ ī�� ���� ��Ȱ��ȭ
            deleteInfo(partySetManager.partyCardIndex);

            // ���õ� ī���� 0�� �ڽĿ�����Ʈ ��Ȱ��ȭ
            partySetCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(false);

            // Ŭ���� ī�� �ʱ�ȭ
            partySetManager.isPartyCardClicked = false;

            // �ε��� �ѹ� �ʱ�ȭ
            partySetManager.partyCardIndex = -1;

            // ��Ƽ �� ī�忡 �ڽ� ������Ʈ�� ���ٸ� ����
            if (partySetCards[partySetCardNum].transform.childCount <= 4) { return; }

            // ��Ƽ �� ī�忡 �ڽ� ������Ʈ�� �ִٸ�,
            else
            {
                // �ڽ� ������Ʈ �ı�
                Destroy(partySetCards[partySetCardNum].transform.GetChild(4).gameObject);

                // ���� �迭�� �ش��ϴ� ��Ҹ� -1�� �ٲ��ݴϴ�.
                partySetManager.cardNums[partySetCardNum] = -1;
            }
        }
    }       // } ��Ƽ�� ī�� Ŭ��

    // { ī�带 �����ؼ� ��Ƽ�� ī��� �����ϱ�
    public void MyCardClick(int partySetCardNum)
    {
        // ��Ƽ�� ī�尡 ������ �ȵǾ��ٸ� return
        if (partySetManager.isPartyCardClicked == false) { return; }

        // ��Ƽ�� ī�尡 ������ �� ���¿��� �÷��̾� ī�带 Ŭ���ߴٸ�
        else
        {
            // �迭�� ������ ī�� ��ȣ�� �ִٸ� (�ߺ��� �Ǿ��ٸ�)
            for (int i = 0; i < partySetManager.cardNums.Length; i++)
            {
                if (partySetManager.cardNums[i] == partySetCardNum)
                {
                   // ������ ī�带 ����ϴ�.
                   Destroy(partySetCards[i].transform.transform.GetChild(4).gameObject);

                    // ������ ī�� ���� ��Ȱ��ȭ
                    deleteInfo(i);

                   // ���� �迭�� �ش��ϴ� ��Ҹ� -1�� �ٲ��ݴϴ�.
                   partySetManager.cardNums[i] = -1;
                }
            }

            // ī�� �ѹ� �迭�� �ش� ī�� ��ȣ�� �ֽ��ϴ�.
            partySetManager.cardNums[partySetManager.partyCardIndex] = partySetCardNum;

            // ������ ������ ��Ƽ ī�尡 �ִٸ�
            if (partySetCards[partySetManager.partyCardIndex].transform.childCount >= 5)
            {
                // ������ ������ ��Ƽ�� ī�� ����
                Destroy(partySetCards[partySetManager.partyCardIndex].transform.GetChild(4).gameObject);

                // ������ ������ ī�� ���� ��Ȱ��ȭ
                deleteInfo(partySetManager.partyCardIndex);
            }

            // �÷��̾� ī���� transform�� ������ ����
            temp_CharacterCard = playerCards[partySetCardNum].transform.GetChild(0).gameObject;

            // ��Ƽ��ī���� �ڽĿ�����Ʈ�� ����
            GameObject playerCard = Instantiate(temp_CharacterCard, Vector2.zero, Quaternion.identity);
            playerCard.transform.SetParent(partySetCards[partySetManager.partyCardIndex].transform);
            
            // ��ġ, ũ�� ����
            playerCard.transform.localScale = new Vector2(1.2f, 1.2f);
            playerCard.transform.position = partySetCards[partySetManager.partyCardIndex].transform.position;

            // ī�� ���� Ȱ��ȭ
            partySetCards[partySetManager.partyCardIndex].transform.GetChild(1).gameObject.SetActive(true);
            partySetCards[partySetManager.partyCardIndex].transform.GetChild(2).gameObject.SetActive(true);

            // ī�� ���� ����
            costs[partySetManager.partyCardIndex].text = string.Format("{0}", GameManager.instance.MyCharacter_List[partySetCardNum].Cost);
            respons[partySetManager.partyCardIndex].text = string.Format("{0}", GameManager.instance.MyCharacter_List[partySetCardNum].ResponeCoolTime);
        }
    }   // } ī�带 �����ؼ� ��Ƽ�� ī��� �����ϱ�

    // ������ ������ ī�� ���� ��Ȱ��ȭ
    private void deleteInfo(int index)
    {
        partySetCards[index].transform.GetChild(1).gameObject.SetActive(false);
        partySetCards[index].transform.GetChild(2).gameObject.SetActive(false);
    }
}
