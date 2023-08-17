using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStageWin : MonoBehaviour
{
    public Canvas stage01;
    public GameObject FightManager;

    public void LoadFightStageScene()
    {
        SceneManager.LoadScene("BattleScene01_Test");
    }

    public void LoadGatchaScene()
    {
        SceneManager.LoadScene("GatchaScene");
    }
}
