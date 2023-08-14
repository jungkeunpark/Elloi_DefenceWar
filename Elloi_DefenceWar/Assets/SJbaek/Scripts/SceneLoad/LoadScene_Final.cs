using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_Final : MonoBehaviour
{
    // �������� ���� ������ �̵�
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    // ��Ʋ �������� ������ �̵�
    public void LoadFightScene()
    {

    }

    // �÷��� �� �����
    public void Restart()
    {
        // ���� ���� �ٽ� �ε��� �������� �����
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
