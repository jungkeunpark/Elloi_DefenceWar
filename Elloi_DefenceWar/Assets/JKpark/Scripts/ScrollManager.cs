using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    public Image[] images;

    public void PressScroll()
    {
        SoundManager.soundManager.PlaySE("ScrollAppear");
        gameObject.transform.parent.transform.parent.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.parent.transform.parent.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.parent.transform.parent.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.parent.transform.parent.transform.GetChild(3).gameObject.SetActive(true);



    }
}
