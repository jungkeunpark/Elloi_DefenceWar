using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 활성화할 캔버스
    public Canvas[] canvases;
    // 활성화할 매니저
    public GameObject[] managers;

    public void ReturnStageSelect()
    {
        canvases[0].gameObject.SetActive(true);
        canvases[1].gameObject.SetActive(false);
        canvases[2].gameObject.SetActive(false);
        managers[0].gameObject.SetActive(false);
        managers[1].gameObject.SetActive(false);

    }

    public void OpenCharacterInfoCanvas()
    {
        canvases[0].gameObject.SetActive(false);
        managers[0].gameObject.SetActive(true);
        canvases[1].gameObject.SetActive(true);
        canvases[2].gameObject.SetActive(false);
    }

    public void OpenPartySetCanavas()
    {
        canvases[0].gameObject.SetActive(false);
        managers[1].gameObject.SetActive(true);
        canvases[1].gameObject.SetActive(false);
        canvases[2].gameObject.SetActive(true);
    }
}
