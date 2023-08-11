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

    void Start()
    {
        TapClick(curRank);
    }

    public void CardClick(int cardNum)
    {
        // 보유중인 카드를 클릭했을 때 정보 보이기
        characterName.text = GameManager.instance.MyCharacter_List[cardNum].Name;
        health.text = GameManager.instance.MyCharacter_List[cardNum].Health;
        damage.text = GameManager.instance.MyCharacter_List[cardNum].Damage;
        defense.text = GameManager.instance.MyCharacter_List[cardNum].Defense;
        attackSpeed.text = GameManager.instance.MyCharacter_List[cardNum].AttackSpeed;
        moveSpeed.text = GameManager.instance.MyCharacter_List[cardNum].MoveSpeed;
        responeCoolTime.text = GameManager.instance.MyCharacter_List[cardNum].ResponeCoolTime;
        responeCoolTime.text = GameManager.instance.MyCharacter_List[cardNum].ResponeCoolTime;
        cost.text = GameManager.instance.MyCharacter_List[cardNum].Cost;
        characterImage.sprite = cards[cardNum].GetComponentInChildren<CardObjDatas>().characterImage.sprite;


        if (GameManager.instance.MyCharacter_List[cardNum].Rank == "HERO")
        {
            characterRank.sprite = ranks[0];
        }
        else if(GameManager.instance.MyCharacter_List[cardNum].Rank == "MASTER")
        {
            characterRank.sprite = ranks[1];
        }
        else if (GameManager.instance.MyCharacter_List[cardNum].Rank == "ELITE")
        {
            characterRank.sprite = ranks[2];
        }
        else if (GameManager.instance.MyCharacter_List[cardNum].Rank == "EXPERT")
        {
            characterRank.sprite = ranks[3];
        }
        else if(GameManager.instance.MyCharacter_List[cardNum].Rank == "NOVICE")
        {
            characterRank.sprite = ranks[4];
        }
    }

    public void TapClick(string tabName)
    {
        // 현재 캐릭터 리스트에 클릭한 랭크 캐릭터만 추가
        curRank = tabName;
        GameManager.instance.CurCharacter_List = GameManager.instance.MyCharacter_List.FindAll(x => x.Rank == curRank);
        
        // 카드 보이기
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].SetActive(i < GameManager.instance.MyCharacter_List.Count);
        }
    }
}
