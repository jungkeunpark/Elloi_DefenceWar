using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightWarriorScripts : MonoBehaviour
{
    public GameObject Character = default;
    public float movespeed = default;
    public Rigidbody2D CharacterRigidbody = default;
    public string characterName;
    public int health;
    public int damage;
    public int defense;
    public int attackSpeed;
    public int moveSpeed;
    public int responeCoolTime;
    public int cost;
    public Image characterImage;
    public Image characterRank;
    public Sprite[] ranks;
    public GameObject[] cards;

    


    public void Summon(int cardNum)
    {
        characterName =  GameManager.instance.MyCharacter_List[cardNum].Name;
        health = int.Parse(GameManager.instance.MyCharacter_List[cardNum].Health);
        Debug.LogFormat("{0} 내 체력 잘 찍히는지?", health);
        damage = int.Parse(GameManager.instance.MyCharacter_List[cardNum].Damage);
        defense = int.Parse(GameManager.instance.MyCharacter_List[cardNum].Defense);
        attackSpeed = int.Parse(GameManager.instance.MyCharacter_List[cardNum].AttackSpeed);
        moveSpeed = int.Parse(GameManager.instance.MyCharacter_List[cardNum].MoveSpeed);
        responeCoolTime = int.Parse(GameManager.instance.MyCharacter_List[cardNum].ResponeCoolTime);
        responeCoolTime = int.Parse(GameManager.instance.MyCharacter_List[cardNum].ResponeCoolTime);
        cost = int.Parse(GameManager.instance.MyCharacter_List[cardNum].Cost);
        characterImage.sprite = cards[cardNum].GetComponentInChildren<CardObjDatas>().characterImage.sprite;


        CharacterRigidbody = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        Vector2 CharacterMoving = new Vector2(moveSpeed, 0);
        CharacterRigidbody.velocity = CharacterMoving;




    }

    //private void OnCollider2D(Collider2D other)
    //{
    //    if(other.tag == "Enemy")
    //    {
    //        EnemyController EnemyController = other.GetComponent<EnemyController>();
    //        if(EnemyController != null)
    //        {
    //            EnemyController.health - damage;
    //        }
    //    }
    //}

    //private void Die()
    //{
    //    if()
    //}
}
