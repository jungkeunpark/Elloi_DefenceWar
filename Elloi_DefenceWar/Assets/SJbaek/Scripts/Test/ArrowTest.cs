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
        // 화살이 공격에 성공했다면
        if (arrowAttacked)
        {
            Debug.Log("닿았다!");
            // 화살 비활성화
            gameObject.SetActive(false);

            enemy.enemyCurHp -= 10;
        }
    }

    void FixedUpdate()
    {
        // 계속 오른쪽으로 이동
        transform.Translate(Vector2.right * arrowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에 닿았다면
        if(collision.CompareTag("Enemy"))
        {
            enemy = collision.GetComponent<Enemy>();
            arrowAttacked = true;
        }

    }
}
