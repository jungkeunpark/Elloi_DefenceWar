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
        // 화살이 공격에 성공했다면
        if (arrowAttacked)
        {
            if (attackEnemy)
            {
                Debug.Log("적에게 닿았다!");
                // 화살 비활성화
                Destroy(gameObject);

                enemy.enemyCurHp -= arrowDamage;
            }
            else if(attackTower)
            {
                Debug.Log("적 타워에 닿았다!");
                // 화살 비활성화
                Destroy(gameObject);
                FightManager.fightManager.curEnemyTowerHp -= arrowDamage;
            }
            
        }
    }

    void FixedUpdate()
    {
        // 계속 오른쪽으로 이동
        transform.Translate(Vector2.left * arrowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에 닿았다면
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
