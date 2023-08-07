using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameText : MonoBehaviour
{
    public TextMeshProUGUI playerName;

    private void Awake()
    {
        playerName = GetComponent<TextMeshProUGUI>();
        playerName.text = GameManager.instance.playerName;
    }
}
