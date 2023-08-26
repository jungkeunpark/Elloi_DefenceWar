using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Unity.Collections.LowLevel.Unsafe;

public class DoTweenTest : MonoBehaviour, IPointerEnterHandler
{
    Tween shakeAni = default;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (shakeAni == null)
        {
            if (!DOTween.IsTweening(transform)) // 객체가 파괴되지 않았고 Tween이 실행 중이 아닐 때
            {
                shakeAni = transform.DOShakeScale(0.5f, 0.5f, 10, 90, true, ShakeRandomnessMode.Harmonic)
                    .SetAutoKill()
                    .OnKill(() => DisposeShake());
            }
            return;
        }
    }

    //! Tween이 kill 될 때, shakeAni 변수를 비워주는 함수
    private void DisposeShake()
    {
        transform.localScale = Vector3.one;
        shakeAni = default;
    }
}
