using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetGold : MonoBehaviour
{
    public int getGold = 0;
    public TextMeshProUGUI getGoldText;

    private void Awake()
    {
        getGold = Random.Range(70, 200);
        getGoldText.text = string.Format("{0}", getGold);
        GameManager.instance.playerGold += getGold;
    }
}
