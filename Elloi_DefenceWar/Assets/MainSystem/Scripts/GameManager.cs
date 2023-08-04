using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴 사용
    public static GameManager instance;

    // 프로그램 실행시 유지할 값들
    public int playerGold = 10000;
    public int playerJuwel = 3000;
    public int playerLevel = 1;
    public int exp = 0;
    public string playerName = "최강미남박정근";

    private void Awake()
    {
        // 존재하고 있지 않다면 다시 최신화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경시 파괴X
        }
        else
        {
            // 중복으로 존재한다면 파괴
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
