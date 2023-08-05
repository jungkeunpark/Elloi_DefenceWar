using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStageSelect : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
    
}
