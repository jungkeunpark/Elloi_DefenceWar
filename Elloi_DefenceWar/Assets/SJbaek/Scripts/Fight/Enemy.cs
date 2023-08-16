using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;

public class Enemy : MonoBehaviour
{
    public int enemyMaxHp = 100;               // ���� �ִ� ü��
    public int enemyCurHp;                      // ���� ���� ü��
    public int enemyDamage = 5;                 // ���� ������
    public int enemyDefense = 5;                // ���� ����
    public float enemyAttackSpeed = 2f;         // ���� ���ݼӵ�
    public float enemyMoveSpeed = 0.3f;         // ���� �̵��ӵ�

    public bool isBattle = false;               // ���� ������ üũ
    public bool isPlayer = false;               // �÷��̾� ���� ������ üũ
    public bool isTower = false;                // Ÿ�� ���� ������ üũ
    public bool isAttack = false;
    public float attackTimer;                   // ���� ��Ÿ��

    public Image enemyHPBar;                    // ���� ü�¹�

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
        // ���
        if (enemyCurHp <= 0)
        {
            EnemyDead();
        }

        // ü�¹� ������Ʈ
        enemyHPBar.fillAmount = (float)enemyCurHp / (float)enemyMaxHp;
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

            // ���� �ӵ� ��Ÿ��
            attackTimer += Time.deltaTime;

            if (attackTimer > enemyAttackSpeed)
            {
                // ���� ����
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
        transform.eulerAngles = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
        isBattle = false;
        isAttack = false;

        playerCharacter.isAttack = false;
        playerCharacter.isBattle = false;
    }
}
