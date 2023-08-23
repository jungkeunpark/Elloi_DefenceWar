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
        if(shakeAni == null || shakeAni == default)
        {
            shakeAni = transform.DOShakeScale(0.5f, 0.5f, 10, 90, true, ShakeRandomnessMode.Harmonic).SetAutoKill();
            shakeAni.onKill += () => DisposeShake();
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
