using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickEffect : MonoBehaviour
{
    SpriteRenderer sprite;
    Vector2 direction;
    public float moveSpeed;         // 이펙트가 이동하는 속도
    public float minSize = 20f;      // 이펙트 최소 크기
    public float maxSize = 50f;      // 이펙트 최대 크기
    public float sizeSpeed = 1;
    public Color[] colors;
    public float colorSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        direction = new Vector2 (Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector2(size, size);
        sprite.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        // 랜덤한 방향으로 계속 이동
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // 이펙트의 크기를 현재크기에서 0까지 줄임
        // Lerp는 선형보간 함수로, 두개의 값 사이를 시간에 따라 부드럽게 이동하는 값을 계산
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorSpeed);
        sprite.color = color;

        if(sprite.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
