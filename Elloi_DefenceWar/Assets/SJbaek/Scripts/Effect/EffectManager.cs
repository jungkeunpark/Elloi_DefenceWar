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
        // 마우스를 클릭할때
        if(Input.GetMouseButton(0) && spawnsTime >= defaultTime)
        {
            // 이펙트 생성
            EffectCreate();
            spawnsTime = 0;
        }
        spawnsTime += Time.unscaledDeltaTime;
    }

    void EffectCreate()
    {
        // 마우스 위치에서 조금씩 랜덤하게 벗어난 위치로 생성
        float offsetX = Random.Range(-offsetRange, offsetRange);
        float offsetY = Random.Range(-offsetRange, offsetRange);

        // 마우스 위치에 랜덤한 오프셋을 적용하여 이펙트의 생성 위치 계산
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPosition.z = 0;
        mPosition.x += offsetX;
        mPosition.y += offsetY;

        // 이펙트 생성
        Instantiate(startPrefab, mPosition, Quaternion.identity);
    }
}
