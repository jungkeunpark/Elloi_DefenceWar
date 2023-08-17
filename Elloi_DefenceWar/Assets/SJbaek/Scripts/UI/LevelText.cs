using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // �ؽ�Ʈ �޽� ����

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    private void Update()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        levelText.text = string.Format("{0}", GameManager.instance.playerLevel);
    }
}
