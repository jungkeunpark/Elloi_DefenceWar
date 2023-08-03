using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class StartScripts : MonoBehaviour
{
    public Camera[] Cameras = default;

    void Awake()
    {
        int a = Random.Range(1, 6);
        Cameras[a].gameObject.SetActive(true);     

    }


}
