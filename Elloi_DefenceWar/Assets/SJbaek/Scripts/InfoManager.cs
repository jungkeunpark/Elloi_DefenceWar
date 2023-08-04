using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.U2D.Animation;

public class InfoManager : MonoBehaviour
{
    private CharacterData characterData;
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

    private void Awake()
    {
        characterData = GameManager.instance.gameDatas[1];

        characterName.text = characterData.characterName;
        health.text = string.Format("{0}", characterData.health);
        damage.text = string.Format("{0}", characterData.damage);
        defense.text = string.Format("{0}", characterData.defense);
        attackSpeed.text = string.Format("{0}", characterData.attackSpeed);
        moveSpeed.text = string.Format("{0}", characterData.moveSpeed);
        responeCoolTime.text = string.Format("{0}", characterData.responeCoolTime);
        cost.text = string.Format("{0}", characterData.cost);
        characterImage.sprite = characterData.characterImage.sprite;
        characterRank.sprite = characterData.characterRank.sprite;
    }
}
