using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_additive : MonoBehaviour
{

    public void RemoveScene()
    {
        Debug.Log("�Լ������");
        SceneManager.UnloadSceneAsync("FightScene_Test");
    }
}
