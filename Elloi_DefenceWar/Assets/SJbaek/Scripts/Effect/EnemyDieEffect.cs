using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieEffect : MonoBehaviour
{
    RectTransform effectRectTransform;
    SpriteRenderer sprite;

    public float moveSpeed;         // 이펙트가 이동하는 속도
    public float minSize = 5f;      // 이펙트 최소 크기
    public float maxSize = 10f;      // 이펙트 최대 크기
    public float sizeSpeed = 1;
    public Color[] colors;
    public float colorSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        effectRectTransform = GetComponent<RectTransform>();
        sprite = GetComponent<SpriteRenderer>();
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector2(size, size);
        sprite.color = colors[Random.Range(0, colors.Length)];
        moveSpeed = Random.Range(20, 40);
    }

    // Update is called once per frame
    void Update()
    {
        // 랜덤한 방향으로 계속 이동
        effectRectTransform.anchoredPosition += moveSpeed * Time.deltaTime * new Vector2(Random.Range(1f, 2f), Random.Range(1f, 2f));

        // 이펙트의 크기를 현재크기에서 0까지 줄임
        // Lerp는 선형보간 함수로, 두개의 값 사이를 시간에 따라 부드럽게 이동하는 값을 계산
        effectRectTransform.sizeDelta = Vector2.Lerp(effectRectTransform.sizeDelta, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.deltaTime * colorSpeed);
        sprite.color = color;

        if (sprite.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
