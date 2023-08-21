using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    public float arrowSpeed = 20.0f;
    public int arrowDamage;

    bool arrowAttacked = false;
    bool attackEnemy = false;
    bool attackTower = false;
    Enemy enemy;

    private void Start()
    {
        arrowDamage = GetComponentInParent<PlayerCharacter>().characterDamage;
    }

    private void Update()
    {
        // ȭ���� ���ݿ� �����ߴٸ�
        if (arrowAttacked)
        {
            if (attackEnemy)
            {
                Debug.Log("������ ��Ҵ�!");
                // ȭ�� ��Ȱ��ȭ
                Destroy(gameObject);

                enemy.enemyCurHp -= arrowDamage;
            }
            else if(attackTower)
            {
                Debug.Log("�� Ÿ���� ��Ҵ�!");
                // ȭ�� ��Ȱ��ȭ
                Destroy(gameObject);
                FightManager.fightManager.curEnemyTowerHp -= arrowDamage;
            }
            
        }
    }

    void FixedUpdate()
    {
        // ��� ���������� �̵�
        transform.Translate(Vector2.left * arrowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��Ҵٸ�
        if(collision.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            arrowAttacked = true;
            attackEnemy = true;
        }
        else if(collision.CompareTag("EnemyTower"))
        {
            arrowAttacked = true;
            attackTower = true;
        }

    }
}
