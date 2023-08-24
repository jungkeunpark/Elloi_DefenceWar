using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private void Start()
    {
        SoundManager.soundManager.PlayBGM("Title_BGM");
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // BGM ����
            SoundManager.soundManager.StopBGM();

            // ȿ���� �ѱ�
            SoundManager.soundManager.PlaySE("TitleSceneClickButton");
            SceneManager.LoadScene("LoadingScene");
        }
    }
}
