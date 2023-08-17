using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject startPrefab;
    float spawnsTime;
    public float defaultTime = 0.05f;
    public float offsetRange = 0.5f;

    void Update()
    {
        // ���콺�� Ŭ���Ҷ�
        if(Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        {
            // ����Ʈ ����
            EffectCreate();
            spawnsTime = 0;
        }
        spawnsTime += Time.unscaledDeltaTime;
    }

    void EffectCreate()
    {
        // ���콺 ��ġ���� ���ݾ� �����ϰ� ��� ��ġ�� ����
        float offsetX = Random.Range(-offsetRange, offsetRange);
        float offsetY = Random.Range(-offsetRange, offsetRange);

        // ���콺 ��ġ�� ������ �������� �����Ͽ� ����Ʈ�� ���� ��ġ ���
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPosition.z = 0;
        mPosition.x += offsetX;
        mPosition.y += offsetY;

        // ����Ʈ ����
        Instantiate(startPrefab, mPosition, Quaternion.identity);
    }
}
