using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemActiveEffect : MonoBehaviour
{
    public float rotationSpeed = 50f;   // ȸ���ӵ�
    public bool isActive = false;

    private void Update()
    {
        if (!isActive) { return; }
        
        else if (isActive)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        isActive = false;
    }
}
