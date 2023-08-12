using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHp = 10;
    public int curHp;
    public int damage = 5;
    public int defense = 5;
    public float attackSpeed = 1f;
    public float moveSpeed = 3f;

    public float attackTimer;
    bool isAttack = false;

    private void Awake()
    {
        curHp = maxHp;
    }

    void Update()
    {
        if (!isAttack)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        if (isAttack)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackSpeed)
            {
                Debug.Log("에너미 어택");
                attackTimer = 0;
            }
        }

        if (curHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            
        }
    }

    private void OnEnable()
    {
        curHp = maxHp;
    }

    private void OnDisable()
    {
        isAttack = false;
    }
}
