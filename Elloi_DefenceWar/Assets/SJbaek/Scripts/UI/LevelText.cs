using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // 텍스트 메쉬 프로

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private void Update()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = string.Format("{0}", GameManager.instance.playerLevel);
    }
}
