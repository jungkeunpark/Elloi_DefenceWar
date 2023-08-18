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
        // 마우스를 클릭할때
        if (Input.GetKey(KeyCode.A) && spawnsTime >= defaultTime)
        {
            // 이펙트 생성
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
        // 생성 위치 에서 조금씩 랜덤하게 벗어난 위치로 생성
        float offsetX = Random.Range(-offsetRange, offsetRange);
        float offsetY = Random.Range(-offsetRange, offsetRange);

        // 이펙트 생성 위치 캔버스의 자식오브젝트로 생성
        GameObject effect = Instantiate(startPrefab, gameCanvas.transform);
        RectTransform effectRectTransform = effect.GetComponent<RectTransform>();
        effectRectTransform.anchoredPosition = new Vector3(offsetX, offsetY, 0f); // 원하는 위치로 수정
        Debug.Log("생성됨");
    }
}
