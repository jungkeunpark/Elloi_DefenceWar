using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickEffect : MonoBehaviour
{
    SpriteRenderer sprite;
    Vector2 direction;
    public float moveSpeed;         // ����Ʈ�� �̵��ϴ� �ӵ�
    public float minSize = 20f;      // ����Ʈ �ּ� ũ��
    public float maxSize = 50f;      // ����Ʈ �ִ� ũ��
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
        // ������ �������� ��� �̵�
        transform.Translate(direction * moveSpeed * Time.unscaledDeltaTime);

        // ����Ʈ�� ũ�⸦ ����ũ�⿡�� 0���� ����
        // Lerp�� �������� �Լ���, �ΰ��� �� ���̸� �ð��� ���� �ε巴�� �̵��ϴ� ���� ���
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.unscaledDeltaTime * sizeSpeed);

        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a, 0, Time.unscaledDeltaTime * colorSpeed);
        sprite.color = color;

        if(sprite.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}