using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MineralTest : MonoBehaviour
{
    public TextMeshProUGUI playerMineral;
    public float curMineral = 0f;
    public float maxMineral = 300f;
    public float increment = 15f;

    private void Update()
    {
        curMineral += Time.deltaTime * increment;

        if (curMineral > maxMineral)
        {
            curMineral = maxMineral;
        }

        playerMineral.text = string.Format("{0} / {1}", (int)curMineral, maxMineral);
    }
}
