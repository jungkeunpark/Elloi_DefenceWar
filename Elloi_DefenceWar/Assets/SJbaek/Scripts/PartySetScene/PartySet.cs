using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartySet : MonoBehaviour
{
    public Sprite tmp;
    public Image imageObject;
    public GameObject currData;
    public bool isFill;

    // 원래 자신 이미지를 가지고 있을 변수

    private void Awake()
    {
        imageObject = GetComponent<Image>();
        isFill = false;
    }

    public void SetImage(Sprite changeImage)
    {
        imageObject.sprite = changeImage;
        isFill = true;
    }
   
    public void CleanImage()
    {
        imageObject.sprite = tmp;
        isFill = false;
        GameManager.instance.selectPartySet = null;
    }
}
