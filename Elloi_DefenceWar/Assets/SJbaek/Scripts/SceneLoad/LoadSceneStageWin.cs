using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStageWin : MonoBehaviour
{
    public Canvas stage01;

    public void LoadStageScene01()
    {
        stage01.gameObject.SetActive(true);
    }

    public void TestLoadStageScene()
    {
        SceneManager.LoadSceneAsync("FightScene_Test", LoadSceneMode.Additive);
    }
}
