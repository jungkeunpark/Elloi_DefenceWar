using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieEffect : MonoBehaviour
{
    RectTransform effectRectTransform;
    SpriteRenderer sprite;

    public float moveSpeed;         // ����Ʈ�� �̵��ϴ� �ӵ�
    public float minSize = 5f;      // ����Ʈ �ּ� ũ��
    public float maxSize = 10f;      // ����Ʈ �ִ� ũ��
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
        // ������ �������� ��� �̵�
        effectRectTransform.anchoredPosition += moveSpeed * Time.deltaTime * new Vector2(Random.Range(1f, 2f), Random.Range(1f, 2f));

        // ����Ʈ�� ũ�⸦ ����ũ�⿡�� 0���� ����
        // Lerp�� �������� �Լ���, �ΰ��� �� ���̸� �ð��� ���� �ε巴�� �̵��ϴ� ���� ���
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
