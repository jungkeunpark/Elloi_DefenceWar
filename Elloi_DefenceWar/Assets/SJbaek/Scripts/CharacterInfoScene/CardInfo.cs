using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    // ĳ���� ����
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI attackSpeed;
    public TextMeshProUGUI moveSpeed;
    public TextMeshProUGUI responeCoolTime;
    public TextMeshProUGUI cost;
    public Image characterImage;
    public Image characterRank;
    public Sprite[] ranks;

    // �÷��̾� ���� ���� ī��
    public string curRank = "HERO";
    public GameObject[] cards;

    // ���� ���� ī�� ����
    public TextMeshProUGUI cardCount;

    private void OnEnable()
    {
        // ���� ���� ī�� ���� �ؽ�Ʈ
        cardCount.text = string.Format("{0}", GameManager.instance.MyCharacter_List.Count);

        // ���� ���� ī�常 Ȱ��ȭ
        for(int i = 0; i < GameManager.instance.myGetCardsNumbers.Count; i++)
        {
            cards[GameManager.instance.myGetCardsNumbers[i]].SetActive(true);
        }
    }

    public void CardClick(int cardNum)
    {
        Debug.Log(cardNum);
        // �������� ī�带 Ŭ������ �� ���� ���̱�
        for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
        {
            // �ε��� ��ȣ�� ������
            if (i == cardNum)
            {
                characterName.text = GameManager.instance.AllCharacter_List[i].Name;
                health.text = GameManager.instance.AllCharacter_List[i].Health;
                damage.text = GameManager.instance.AllCharacter_List[i].Damage;
                defense.text = GameManager.instance.AllCharacter_List[i].Defense;
                attackSpeed.text = GameManager.instance.AllCharacter_List[i].AttackSpeed;
                moveSpeed.text = GameManager.instance.AllCharacter_List[i].MoveSpeed;
                responeCoolTime.text = GameManager.instance.AllCharacter_List[i].ResponeCoolTime;
                responeCoolTime.text = GameManager.instance.AllCharacter_List[i].ResponeCoolTime;
                cost.text = GameManager.instance.AllCharacter_List[i].Cost;

                characterImage.sprite = cards[i].GetComponentInChildren<CardObjDatas>().characterImage.sprite;
                characterImage.SetNativeSize();
                characterImage.transform.localScale = new Vector3(1.1f, 1.1f, 1.0f);

                if (GameManager.instance.AllCharacter_List[i].Rank == "HERO")
                {
                    characterRank.sprite = ranks[0];
                }
                else if (GameManager.instance.AllCharacter_List[i].Rank == "MASTER")
                {
                    characterRank.sprite = ranks[1];
                }
                else if (GameManager.instance.AllCharacter_List[i].Rank == "ELITE")
                {
                    characterRank.sprite = ranks[2];
                }
                else if (GameManager.instance.AllCharacter_List[i].Rank == "EXPERT")
                {
                    characterRank.sprite = ranks[3];
                }
                else if (GameManager.instance.AllCharacter_List[i].Rank == "NOVICE")
                {
                    characterRank.sprite = ranks[4];
                }
            }
        }

        
    }

    //public void TapClick(string tabName)
    //{
    //    // ���� ĳ���� ����Ʈ�� Ŭ���� ��ũ ĳ���͸� �߰�
    //    curRank = tabName;
    //    GameManager.instance.CurCharacter_List = GameManager.instance.MyCharacter_List.FindAll(x => x.Rank == curRank);
        
    //    // ī�� ���̱�
    //    for (int i = 0; i < cards.Length; i++)
    //    {
    //        cards[i].SetActive(i < GameManager.instance.MyCharacter_List.Count);
    //    }
    //}
}
