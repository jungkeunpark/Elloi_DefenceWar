using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float speed = 1f;
    public float damage = 10;
    public float attackSpeed = 1.1f;
    public float attackSpeed2 = 1.5f;

    public float attackTimer = 0;
    public float attackTimer2 = 0;

    public bool isMove = true;
    public bool isAttack = false;

    private void Update()
    {
        if (isMove)
        {
            Vector2 moveDirection = Vector2.left * speed * Time.deltaTime;
            transform.Translate(moveDirection);
        }

        if (isAttack)
        {
            attackTimer += Time.deltaTime * attackSpeed;
            attackTimer2 += Time.deltaTime * attackSpeed2;

            if (attackTimer > 1f)
            {
                Debug.Log("1.1초 공격함");
                attackTimer = 0f;
            }

            if (attackTimer2 > 1f)
            {
                Debug.Log("1.5초 공격함");
                attackTimer2 = 0f;
            }  
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag.Equals("PartyCard"))
        {
            isMove = false;
            isAttack = true;
        }
    }
}
