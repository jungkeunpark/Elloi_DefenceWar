using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public float waitTime = 1.5f;
    public float currentTime = default;

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > waitTime)
        {
            SceneManager.LoadScene("StageSelectScene");
        }
    }
}
