using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    // 캐릭터 정보
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

    // 플레이어 보유 중인 카드
    public string curRank = "HERO";
    public GameObject[] cards;

    // 보유 중인 카드 갯수
    public TextMeshProUGUI cardCount;

    private void OnEnable()
    {
        // 내가 가진 카드 갯수 텍스트
        cardCount.text = string.Format("{0}", GameManager.instance.MyCharacter_List.Count);

        // 내가 가진 카드만 활성화
        for(int i = 0; i < GameManager.instance.myGetCardsNumbers.Count; i++)
        {
            cards[GameManager.instance.myGetCardsNumbers[i]].SetActive(true);
        }
    }

    public void CardClick(int cardNum)
    {
        Debug.Log(cardNum);
        // 보유중인 카드를 클릭했을 때 정보 보이기
        for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
        {
            // 인덱스 번호가 같으면
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
    //    // 현재 캐릭터 리스트에 클릭한 랭크 캐릭터만 추가
    //    curRank = tabName;
    //    GameManager.instance.CurCharacter_List = GameManager.instance.MyCharacter_List.FindAll(x => x.Rank == curRank);
        
    //    // 카드 보이기
    //    for (int i = 0; i < cards.Length; i++)
    //    {
    //        cards[i].SetActive(i < GameManager.instance.MyCharacter_List.Count);
    //    }
    //}
}
