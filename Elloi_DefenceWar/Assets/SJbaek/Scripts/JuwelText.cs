using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JuwelText : MonoBehaviour
{
    public TextMeshProUGUI juwelText;

    void Awake()
    {
        juwelText = GetComponent<TextMeshProUGUI>();
        juwelText.text = string.Format("{0}", GameManager.instance.playerJuwel);
    }
}
