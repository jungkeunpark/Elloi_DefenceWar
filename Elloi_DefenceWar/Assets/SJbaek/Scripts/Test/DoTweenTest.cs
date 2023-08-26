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
            if (!DOTween.IsTweening(transform)) // ��ü�� �ı����� �ʾҰ� Tween�� ���� ���� �ƴ� ��
            {
                shakeAni = transform.DOShakeScale(0.5f, 0.5f, 10, 90, true, ShakeRandomnessMode.Harmonic)
                    .SetAutoKill()
                    .OnKill(() => DisposeShake());
            }
            return;
        }
    }

    //! Tween�� kill �� ��, shakeAni ������ ����ִ� �Լ�
    private void DisposeShake()
    {
        transform.localScale = Vector3.one;
        shakeAni = default;
    }
}
