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

    // ���� �ڽ� �̹����� ������ ���� ����

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
