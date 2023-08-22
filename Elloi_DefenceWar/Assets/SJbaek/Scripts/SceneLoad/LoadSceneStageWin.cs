using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneStageWin : MonoBehaviour
{
    // 클리어 시 골드 버튼으로 변경
    public Sprite clearButton;
    // 클리어 시 깃발 자식오브젝트 활성화
    public Button[] stageButtons;

    // 클리어 한 스테이지 버튼바꾸기 및 깃발 활성화
    public void Start()
    {
        foreach(int index in GameManager.instance.clearStageIndex)
        {
            if (index == -1) { continue; }

            else if (index >= 0)
            {
                // 골드 버튼으로 변경
                stageButtons[index].image.sprite = clearButton;

                // 깃발 활성화
                stageButtons[index].transform.GetChild(0).gameObject.SetActive(true);
            }

            else { continue; }
        } 
    }

    public void LoadGatchaScene()
    {
        SceneManager.LoadScene("GatchaScene");
    }

    // Load 스테이지
    public void LoadFightStage00Scene()
    {
        SceneManager.LoadScene("BattleScene00");
    }

    public void LoadFightStage01Scene()
    {
        SceneManager.LoadScene("BattleScene01");
    }

    public void LoadFightStage02Scene()
    {
        SceneManager.LoadScene("BattleScene02");
    }

    public void LoadFightStage03Scene()
    {
        SceneManager.LoadScene("BattleScene03");
    }

    public void LoadFightStage04Scene()
    {
        SceneManager.LoadScene("BattleScene04");
    }

    public void LoadFightStage05Scene()
    {
        SceneManager.LoadScene("BattleScene05");
    }

    public void LoadFightStage06Scene()
    {
        SceneManager.LoadScene("BattleScene06");
    }

    public void LoadFightStage07Scene()
    {
        SceneManager.LoadScene("BattleScene07");
    }

    public void LoadFightStage08Scene()
    {
        SceneManager.LoadScene("BattleScene08");
    }

    public void LoadFightStage09Scene()
    {
        SceneManager.LoadScene("BattleScene09");
    }

    public void LoadFightStage10Scene()
    {
        SceneManager.LoadScene("BattleScene10");
    }

    public void LoadFightStage11Scene()
    {
        SceneManager.LoadScene("BattleScene11");
    }

    public void LoadFightStage12Scene()
    {
        SceneManager.LoadScene("BattleScene12");
    }

    public void LoadFightStage13Scene()
    {
        SceneManager.LoadScene("BattleScene13");
    }

    public void LoadFightStage14Scene()
    {
        SceneManager.LoadScene("BattleScene14");
    }

    public void LoadFightStage15Scene()
    {
        SceneManager.LoadScene("BattleScene15");
    }
}
