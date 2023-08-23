using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieEffectManagerTest : MonoBehaviour
{
    public GameObject startPrefab;
    public Canvas gameCanvas;
    float spawnsTime;
    public float defaultTime = 0.05f;
    public int offsetRange = 500;

    void Update()
    {
        // ���콺�� Ŭ���Ҷ�
        if (Input.GetKey(KeyCode.A) && spawnsTime >= defaultTime)
        {
            // ����Ʈ ����
            for(int i = 0; i < 20; i++)
            {
                EffectCreate();
            }
            
            spawnsTime = 0;
        }
        spawnsTime += Time.unscaledDeltaTime;
    }

    void EffectCreate()
    {
        // ���� ��ġ ���� ���ݾ� �����ϰ� ��� ��ġ�� ����
        float offsetX = Random.Range(-offsetRange, offsetRange);
        float offsetY = Random.Range(-offsetRange, offsetRange);

        // ����Ʈ ���� ��ġ ĵ������ �ڽĿ�����Ʈ�� ����
        GameObject effect = Instantiate(startPrefab, gameCanvas.transform);
        RectTransform effectRectTransform = effect.GetComponent<RectTransform>();
        effectRectTransform.anchoredPosition = new Vector3(offsetX, offsetY, 0f); // ���ϴ� ��ġ�� ����
        Debug.Log("������");
    }
}
