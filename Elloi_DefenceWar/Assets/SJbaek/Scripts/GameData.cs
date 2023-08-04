using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterData", menuName = "GameData/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int health;
    public int damage;
    public int defense;
    public float attackSpeed;
    public int moveSpeed;
    public float responeCoolTime;
    public int cost;
    public int rank;
    public Image characterImage;
    public Image characterRank;
}
