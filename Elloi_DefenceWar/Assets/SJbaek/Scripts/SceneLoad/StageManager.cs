using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class StageManager : MonoBehaviour
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

    private void Awake()
    {
        // BGM 켜기
        SoundManager.soundManager.PlayBGM("MainScene_BGM");
        // 볼륨 조절
        SoundManager.soundManager.SetBGMVolume(0.5f);
    }

    public void LoadGatchaScene()
    {
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 가챠 씬 로드
        SceneManager.LoadScene("GatchaScene");
    }

    // Load 스테이지
    public void LoadFightStage00Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene00");
    }

    public void LoadFightStage01Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene01");
    }

    public void LoadFightStage02Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene02");
    }

    public void LoadFightStage03Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene03");
    }

    public void LoadFightStage04Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene04");
    }

    public void LoadFightStage05Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene05");
    }

    public void LoadFightStage06Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene06");
    }

    public void LoadFightStage07Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene07");
    }

    public void LoadFightStage08Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene08");
    }

    public void LoadFightStage09Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene09");
    }

    public void LoadFightStage10Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene10");
    }

    public void LoadFightStage11Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene11");
    }

    public void LoadFightStage12Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene12");
    }

    public void LoadFightStage13Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene13");
    }

    public void LoadFightStage14Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene14");
    }

    public void LoadFightStage15Scene()
    {
        // 효과음 켜기
        SoundManager.soundManager.PlaySE("TitleSceneClickButton");
        // BGM 끄기
        SoundManager.soundManager.StopBGM();
        // 스테이지 로드
        StageLoadScene.LoadScene("BattleScene00");
    }
}
