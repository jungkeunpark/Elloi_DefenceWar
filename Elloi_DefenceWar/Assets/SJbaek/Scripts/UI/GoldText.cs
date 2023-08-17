using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldText : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private void Awake()
    {
        goldText = GetComponent<TextMeshProUGUI>();
        goldText.text = string.Format("{0}", GameManager.instance.playerGold);
    }

    private void Update()
    {
        goldText = GetComponent<TextMeshProUGUI>();
        goldText.text = string.Format("{0}", GameManager.instance.playerGold);
    }
}
