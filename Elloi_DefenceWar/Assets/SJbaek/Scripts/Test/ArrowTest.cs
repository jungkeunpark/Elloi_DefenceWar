using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    public float arrowSpeed = 20.0f;

    bool arrowAttacked = false;
    Enemy enemy;

    private void Update()
    {
        // ȭ���� ���ݿ� �����ߴٸ�
        if (arrowAttacked)
        {
            Debug.Log("��Ҵ�!");
            // ȭ�� ��Ȱ��ȭ
            gameObject.SetActive(false);

            enemy.enemyCurHp -= 10;
        }
    }

    void FixedUpdate()
    {
        // ��� ���������� �̵�
        transform.Translate(Vector2.right * arrowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��Ҵٸ�
        if(collision.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            arrowAttacked = true;
        }

    }
}
