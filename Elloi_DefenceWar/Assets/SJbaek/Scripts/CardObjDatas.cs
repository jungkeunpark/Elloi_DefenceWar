using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardObjDatas : MonoBehaviour
{
    public Image backGround01;
    public Image backGround02;
    public Image characterImage;
    public TextMeshProUGUI characterText;
    public Image rank;

    private void Awake()
    {
        // 0번째
        Transform firstObj = gameObject.transform.GetChild(0);
        backGround01 = firstObj.GetComponent<Image>();

        // 1번째
        Transform secondObj = gameObject.transform.GetChild(1);
        backGround02 = secondObj.GetComponent<Image>();

        // 2번째
        Transform thirdObj = gameObject.transform.GetChild(2);
        characterImage = thirdObj.GetComponent<Image>();

        // 4번째
        Transform fifthObj = gameObject.transform.GetChild(4);
        characterText = fifthObj.GetComponent<TextMeshProUGUI>();

        // 5번째
        Transform sixthObj = gameObject.transform.GetChild(5);
        rank = sixthObj.GetComponent<Image>();
    }



}
