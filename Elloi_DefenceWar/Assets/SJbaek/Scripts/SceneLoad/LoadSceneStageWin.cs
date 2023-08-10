using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStageWin : MonoBehaviour
{
    public Canvas stage01;
    public GameObject FightManager;

    public void LoadStageScene01()
    {
        FightManager.gameObject.SetActive(true);
        stage01.gameObject.SetActive(true);
    }
}
