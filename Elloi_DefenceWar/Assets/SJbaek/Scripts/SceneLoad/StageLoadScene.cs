using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoadScene : MonoBehaviour
{
    // �ε� ��
    public float timer;

    void Start()
    {
        StartCoroutine(Cor_LoadScene());
    }

    // �ε� ��
    public static void LoadScene(string sceneName)
    {
        GameManager.instance.nextScene = sceneName;
        SceneManager.LoadScene("StageLoadingScene");
    }

    IEnumerator Cor_LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(GameManager.instance.nextScene);
        op.allowSceneActivation = false;
        timer = 0.0f;
        while (op.isDone == false)
        {
            yield return null;
            timer += Time.deltaTime;

            if (timer > 1.0f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
            
        }
    }
}
