using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoadScene : MonoBehaviour
{
    // ·Îµù ¾À
    public float timer;

    void Start()
    {
        StartCoroutine(Cor_LoadScene());
    }

    // ·Îµù ¾À
    public static void LoadScene(string sceneName)
    {
        GameManager.instance.nextScene = sceneName;
        SceneManager.LoadScene("StageLoadingScene");
    }

    IEnumerator Cor_LoadScene()
    {
        yield return null;

        SceneManager.LoadSceneAsync(GameManager.instance.nextScene);

        timer = 0.0f;

        while (true)
        {
            yield return null;
            timer += Time.deltaTime;

            if (timer > 1.5f)
            {
                yield break;
            }
            
        }
    }
}
