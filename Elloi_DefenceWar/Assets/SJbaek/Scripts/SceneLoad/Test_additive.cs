using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_additive : MonoBehaviour
{

    public void RemoveScene()
    {
        Debug.Log("ÇÔ¼ö½ÇÇàµÊ");
        SceneManager.UnloadSceneAsync("FightScene_Test");
    }
}
