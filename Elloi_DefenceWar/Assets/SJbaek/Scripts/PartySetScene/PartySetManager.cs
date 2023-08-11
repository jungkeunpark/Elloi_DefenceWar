using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartySetManager : MonoBehaviour
{
    public PartySetManager partySetManager;

    // ��Ƽ ī�尡 ���õǾ��ִ��� ����
    public bool isPartyCardClicked = false;

    // ��� ° ��Ƽ �� ī�带 �����ߴ���?
    public int partyCardIndex = -1;

    // ������ ī�� üũ
    public int[] cardNums = new int[4] { -1, -1, -1, -1 };

    // (����) ��Ƽ�� ī��
    public GameObject[] partySetCards;
    public int selectedCardNum;

    // (������) �÷��̾� ī��
    public GameObject[] playerCards;
    public GameObject temp_CharacterCard;

    // ��Ƽ�� ī�� ����
    public TextMeshProUGUI[] costs;
    public TextMeshProUGUI[] respons;

    private void Awake()
    {
        partySetManager = GetComponent<PartySetManager>();
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

            // ������ �÷��̾� ī�� �̵�
            DeletedCardMove(partySetCardNum);

            // �ε��� �ѹ� �ʱ�ȭ
            partySetManager.partyCardIndex = -1;

            // ��Ƽ �� ī�忡 �ڽ� ������Ʈ�� ���ٸ� ����
            if (partySetCards[partySetCardNum].transform.childCount <= 4) { return; }

            // ��Ƽ �� ī�忡 �ڽ� ������Ʈ�� �ִٸ�,
            else
            {
                // �÷��̾� ī���� ����Ʈ ����
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.GetChild(0).gameObject.SetActive(false);
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.GetChild(1).gameObject.SetActive(false);

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
        // ��Ƽ�� ī�尡 ������ �ȵǾ��ų� ������ ĳ���� ī�带 Ŭ���ߴٸ�
        if (partySetManager.isPartyCardClicked == false || partySetManager.cardNums[partySetManager.partyCardIndex] == partySetCardNum) { return; }

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

            // ������ ������ ��Ƽ ī�尡 �ִٸ�
            if (partySetCards[partySetManager.partyCardIndex].transform.childCount >= 5)
            {
                // ������ ������ ��Ƽ�� ī�� ����
                Destroy(partySetCards[partySetManager.partyCardIndex].transform.GetChild(4).gameObject);

                // ������ ������ ī�� ���� ��Ȱ��ȭ
                deleteInfo(partySetManager.partyCardIndex);

                // ������ ������ ī�� ����Ʈ ��Ȱ��ȭ
                playerCards[partySetManager.cardNums[partySetManager.partyCardIndex]].transform.GetChild(0).gameObject.SetActive(false);
                playerCards[partySetManager.cardNums[partySetManager.partyCardIndex]].transform.GetChild(1).gameObject.SetActive(false);
            }

            // ī�� �ѹ� �迭�� �ش� ī�� ��ȣ�� �ֽ��ϴ�.
            partySetManager.cardNums[partySetManager.partyCardIndex] = partySetCardNum;

            // ī�� �̵�
            MoveCard(partySetCardNum);

            // ī�� ����Ʈ Ȱ��ȭ
            playerCards[partySetCardNum].transform.GetChild(0).gameObject.SetActive(true);
            playerCards[partySetCardNum].transform.GetChild(1).gameObject.SetActive(true);

            // �÷��̾� ī���� transform�� ������ ����
            temp_CharacterCard = playerCards[partySetCardNum].transform.GetChild(1).gameObject;

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

    // ī�� �̵�
    private void MoveCard(int partySetCardNum)
    {
        // { ���õ� ī�带 ��Ƽ�� ��ȣ�� �ڽĿ�����Ʈ �ε��� ��ȣ�� �����մϴ�.

        // ( ����.1 ) 0�� x, 1�� x, 2�� x, 3�� x
        // ��> 0������ �̵�
        if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            playerCards[partySetCardNum].transform.SetSiblingIndex(0);
        }

        // ( ����. 2 ) 0�� x, 1�� o, 2�� x, 3�� x
        // ( ����. 2 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1�� ==> 0������ �̵�
        // ( ����. 2 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 2��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 3 ) 0�� x, 1�� x, 2�� O, 3�� x 
        // ( ����. 3 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1��, 2�� ==> 0������ �̵�
        // ( ����. 3 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 4 ) 0�� x, 1�� x, 2�� x, 3�� O
        // ��> 0������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            playerCards[partySetCardNum].transform.SetSiblingIndex(0);
        }

        // ( ����. 5 ) 0�� x, 1�� O, 2�� O, 3�� x
        // ( ����. 5 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1�� ==> 0������ �̵�
        // ( ����. 5 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 2�� ==> 1������ �̵�
        // ( ����. 5 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 6 ) 0�� x, 1�� x, 2�� O, 3�� O
        // ( ����. 6 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1��, 2�� ==> 0������ �̵�
        // ( ����. 6 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 7 ) 0�� x, 1�� O, 2�� x, 3�� O
        // ( ����. 7 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1�� ==> 0������ �̵�
        // ( ����. 7 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 2��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 8 ) 0�� x, 1�� o, 2�� o, 3�� o
        // ( ����. 8 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1�� ==> 0������ �̵�
        // ( ����. 8 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 2�� ==> 1������ �̵�
        // ( ����. 8 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0 || partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 9 ) 0�� o, 1�� x, 2�� x, 3�� x
        // ( ����. 9 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 9 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1��, 2��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }
        // ( ����. 10 ) 0�� o, 1�� o, 2�� x, 3�� x
        // ( ����. 10 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 10 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1�� ==> 1������ �̵�
        // ( ����. 10 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 2��, 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 11 ) 0�� o, 1�� o, 2�� o, 3�� x
        // ( ����. 11 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 11 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1�� ==> 1������ �̵�
        // ( ����. 11 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 2��, 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }


        // ( ����. 12 ) 0�� o, 1�� o, 2�� x, 3�� o
        // ( ����. 12 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 12 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1�� ==> 1������ �̵�
        // ( ����. 12 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 2��, 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 13 ) 0�� o, 1�� x, 2�� o, 3�� x
        // ( ����. 13 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 13 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1��, 2�� ==> 1������ �̵�
        // ( ����. 13 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 14 ) 0�� o, 1�� x, 2�� o, 3�� o
        // ( ����. 14 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 14 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1��, 2�� ==> 1������ �̵�
        // ( ����. 14 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 15 ) 0�� o, 1�� x, 2�� x, 3�� o
        // ( ����. 15 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 15 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1��, 2��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1 || partySetManager.partyCardIndex == 2 || partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 16 ) 0�� o, 1�� o, 2�� o, 3�� o
        // ( ����. 16 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        // ( ����. 16 - 2 ) �÷��̾ ������ ��Ƽ ��ȣ 1�� ==> 1������ �̵�
        // ( ����. 16 - 3 ) �÷��̾ ������ ��Ƽ ��ȣ 2�� ==> 2������ �̵�
        // ( ����. 16 - 4 ) �÷��̾ ������ ��Ƽ ��ȣ 3�� ==> 3������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetManager.partyCardIndex == 0)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(0);
            }
            else if (partySetManager.partyCardIndex == 1)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(1);
            }
            else if (partySetManager.partyCardIndex == 2)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(2);
            }
            else if (partySetManager.partyCardIndex == 3)
            {
                playerCards[partySetCardNum].transform.SetSiblingIndex(3);
            }
        }
        // } ���õ� ī�带 ��Ƽ�� ��ȣ�� �ڽĿ�����Ʈ �ε��� ��ȣ�� �����մϴ�.
    }

    // ��Ƽ�¿��� ������ ī�带 �̵���ŵ�ϴ�.
    private void DeletedCardMove(int partySetCardNum)
    {
        // ( ����. 1 ) 0�� x, 1�� O, 2�� O, 3�� x
        // ( ����. 1 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 1��,2�� ==> 1������ �̵�
        if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 1 || partySetCardNum == 2)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 2 ) 0�� x, 1�� x, 2�� O, 3�� O
        // ( ����. 2 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 2��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 3 ) 0�� x, 1�� O, 2�� x, 3�� O
        // ( ����. 3 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 1��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 1 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 4 ) 0�� x, 1�� o, 2�� o, 3�� o
        // ( ����. 4 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 1��, 2��, 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] == -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 1 || partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 5 ) 0�� o, 1�� x, 2�� x, 3�� x
        // ( ����. 5 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0�� ==> 0������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(0);
            }
        }
        // ( ����. 6 ) 0�� o, 1�� o, 2�� x, 3�� x
        // ( ����. 6 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 7 ) 0�� o, 1�� o, 2�� o, 3�� x
        // ( ����. 7 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1��, 2�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1 || partySetCardNum == 2)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 8 ) 0�� o, 1�� o, 2�� x, 3�� o
        // ( ����. 8 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 1��, 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 9 ) 0�� o, 1�� x, 2�� o, 3�� x
        // ( ����. 9 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 2�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] == -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 2)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 10 ) 0�� o, 1�� x, 2�� o, 3�� o
        // ( ����. 10 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 2��, 3�� ==> 2������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(2);
            }
        }

        // ( ����. 11 ) 0�� o, 1�� x, 2�� x, 3�� o
        // ( ����. 11 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��, 3�� ==> 1������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] == -1 && partySetManager.cardNums[2] == -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(1);
            }
        }

        // ( ����. 12 ) 0�� o, 1�� o, 2�� o, 3�� o
        // ( ����. 12 - 1 ) �÷��̾ ������ ��Ƽ ��ȣ 0��,1��,2��,3�� ==> 3������ �̵�
        else if (partySetManager.cardNums[0] != -1 && partySetManager.cardNums[1] != -1 && partySetManager.cardNums[2] != -1 && partySetManager.cardNums[3] != -1)
        {
            if (partySetCardNum == 0 || partySetCardNum == 1 || partySetCardNum == 2 || partySetCardNum == 3)
            {
                playerCards[partySetManager.cardNums[partySetCardNum]].transform.SetSiblingIndex(3);
            }
        }
        // } ���õ� ī�带 ��Ƽ�� ��ȣ�� �ڽĿ�����Ʈ �ε��� ��ȣ�� �����մϴ�.
    }
}
