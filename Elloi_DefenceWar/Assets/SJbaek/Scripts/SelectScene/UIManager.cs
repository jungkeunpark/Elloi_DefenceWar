using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas[] canvases;

    public void ReturnStageSelect()
    {
        canvases[0].gameObject.SetActive(true);
        canvases[1].gameObject.SetActive(false);
        canvases[2].gameObject.SetActive(false);
        canvases[3].gameObject.SetActive(false);
    }

    public void OpenCharacterInfoCanvas()
    {
        canvases[0].gameObject.SetActive(false);
        canvases[1].gameObject.SetActive(true);
        canvases[2].gameObject.SetActive(false);
        canvases[3].gameObject.SetActive(false);
    }

    public void OpenPartySetCanavas()
    {
        canvases[0].gameObject.SetActive(false);
        canvases[1].gameObject.SetActive(false);
        canvases[2].gameObject.SetActive(true);
        canvases[3].gameObject.SetActive(false);
    }

    public void OpenGatchaCanvas()
    {
        canvases[0].gameObject.SetActive(false);
        canvases[1].gameObject.SetActive(false);
        canvases[2].gameObject.SetActive(false);
        canvases[3].gameObject.SetActive(true);
    }
}
