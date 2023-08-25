using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    // Ŭ���� �� ��� ��ư���� ����
    public Sprite clearButton;
    // Ŭ���� �� ��� �ڽĿ�����Ʈ Ȱ��ȭ
    public Button[] stageButtons;

    // Ŭ���� �� �������� ��ư�ٲٱ� �� ��� Ȱ��ȭ
    public void Start()
    {
        foreach(int index in GameManager.instance.clearStageIndex)
        {
            if (index == -1) { continue; }

            else if (index >= 0)
            {
                // ��� ��ư���� ����
                stageButtons[index].image.sprite = clearButton;

                // ��� Ȱ��ȭ
                stageButtons[index].transform.GetChild(0).gameObject.SetActive(true);
            }

            else { continue; }
        } 
    }


    private void Awake()
    {
        // BGM �ѱ�
        SoundManager.soundManager.PlayBGM("MainScene_BGM");
        // ���� ����
        SoundManager.soundManager.SetBGMVolume(0.5f);
    }

    public void LoadGatchaScene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // ��í �� �ε�
        SceneManager.LoadScene("GatchaScene");
    }

    // Load ��������
    public void LoadFightStage00Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene00");
    }

    public void LoadFightStage01Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene01");
    }

    public void LoadFightStage02Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene02");
    }

    public void LoadFightStage03Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene03");
    }

    public void LoadFightStage04Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene04");
    }

    public void LoadFightStage05Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene05");
    }

    public void LoadFightStage06Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene06");
    }

    public void LoadFightStage07Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene07");
    }

    public void LoadFightStage08Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene08");
    }

    public void LoadFightStage09Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene09");
    }

    public void LoadFightStage10Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene10");
    }

    public void LoadFightStage11Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene11");
    }

    public void LoadFightStage12Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene12");
    }

    public void LoadFightStage13Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene13");
    }

    public void LoadFightStage14Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene14");
    }

    public void LoadFightStage15Scene()
    {
        // BGM ����
        SoundManager.soundManager.StopBGM();
        // �������� �ε�
        SceneManager.LoadScene("BattleScene15");
    }
}
