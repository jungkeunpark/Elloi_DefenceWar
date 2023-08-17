using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_Final : MonoBehaviour
{
    // 스테이지 선택 씬으로 이동
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    // 배틀 스테이지 씬으로 이동
    public void LoadFightScene()
    {

    }

    // 플레이 씬 재시작
    public void Restart()
    {
        // 현재 씬을 다시 로드해 스테이지 재시작
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
