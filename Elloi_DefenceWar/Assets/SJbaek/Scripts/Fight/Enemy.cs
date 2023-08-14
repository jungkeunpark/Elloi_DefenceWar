using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHp = 1000;
    public int enemyCurHp;
    public int enemyDamage = 5;
    public int enemyDefense = 5;
    public float enemyAttackSpeed = 2f;
    public float enemyMoveSpeed = 0.3f;

    public bool isBattle = false;               // 전투 중인지 체크
    public bool isPlayer = false;               // 플레이어 공격 중인지 체크
    public bool isTower = false;                // 타워 공격 중인지 체크
    public bool isAttack = false;
    public float attackTimer;                   // 공격 쿨타임

    PlayerCharacter playerCharacter;

    private void Awake()
    {
        enemyCurHp = enemyMaxHp;
    }

    private void OnEnable()
    {
        enemyCurHp = enemyMaxHp;
    }

    private void Update()
    {
        // 사망
        if (enemyCurHp <= 0)
        {
            EnemyDead();
        }
    }

    void FixedUpdate()
    {
        if (!isBattle && !isAttack)
        {
            transform.Translate(enemyMoveSpeed * Time.deltaTime * Vector2.left);
        }

        if (isBattle)
        {
            transform.Translate(Vector3.zero);

            // 공격 속도 쿨타임
            attackTimer += Time.deltaTime;

            if (attackTimer > enemyAttackSpeed)
            {
                // 공격 시작
                isAttack = true;
                attackTimer = 0;
            }

            if (isAttack && attackTimer == 0)
            {
                if(isPlayer)
                {
                    playerCharacter.characterCurHP -= enemyDamage;
                    isAttack = false;
                }
                else if(isTower)
                {
                    FightManager.fightManager.curPlayerTowerHp -= enemyDamage;
                    isAttack = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCharacter = collision.GetComponent<PlayerCharacter>();
            isBattle = true;
            isAttack = true;
            isPlayer = true;
            isTower = false;
        }

        else if (collision.CompareTag("PlayerTower"))
        {
            isBattle = true;
            isAttack = true;
            isPlayer = false;
            isTower = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerTower"))
        {
            isBattle = true;
            isAttack = true;
            isPlayer = false;
            isTower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isBattle = false;
            isTower = true;
        }
    }

    public void EnemyDead()
    {
        gameObject.SetActive(false);
        isBattle = false;
        isAttack = false;

        playerCharacter.isAttack = false;
        playerCharacter.isBattle = false;
    }
}
