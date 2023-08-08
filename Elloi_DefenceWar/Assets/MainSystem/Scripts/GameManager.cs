using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

[System.Serializable]
public class Character
{
    public Character (string _Rank, string _Name, string _Health, string _Damage, string _Defense, string _AttackSpeed, string _MoveSpeed, string _ResponeCoolTime, string _Cost, bool _isGet)
    { Rank = _Rank; Name = _Name; Health = _Health; Damage = _Damage; Defense = _Defense; AttackSpeed = _AttackSpeed; MoveSpeed = _MoveSpeed; ResponeCoolTime = _ResponeCoolTime; Cost = _Cost; isGet = _isGet; }

    public string Rank, Name, Health, Damage, Defense, AttackSpeed, MoveSpeed, ResponeCoolTime, Cost;
    public bool isGet;
}

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴 사용
    public static GameManager instance;

    // 프로그램 실행시 유지할 값들

    // UI 데이터
    public int playerGold = 10000;
    public int playerJuwel = 3000;
    public int playerLevel = 1;
    public int exp = 0;
    public string playerName = "최강미남박정근";

    // 파티 구성 된 캐릭터 카드
    public GameObject[] partySetCard = new GameObject[4];
    public int[] partySetCardIndex = new int[4] { -1, -1, -1, -1 };

    // 게임 데이터
    public TextAsset CharacterDatabase; // 캐릭터 데이터
    public List<Character> AllCharacter_List, MyCharacter_List, CurCharacter_List;

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

    private void Start()
    {
        // 전체 캐릭터 리스트 불러오기
        string[] line = CharacterDatabase.text.Substring(0, CharacterDatabase.text.Length -1).Split('\n');

        // print(line.Length); // 잘 들어갔는지 test
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');
            AllCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9] == "TRUE"));
        }

        // 내 캐릭터 리스트 불러오기
        Load();
    }

    // JSON 데이터 저장하는 함수
    void Save()
    {
        // JSON 사용하기 (List를 String으로 컨버트 해줍니다.)
        string jdata = JsonConvert.SerializeObject(AllCharacter_List);
        print(jdata);

        // 내 캐릭터 리스트 저장
        File.WriteAllText(Application.dataPath + "/Resources/MyCharacterList.txt", jdata);
    }

    // JSON 데이터 불러오는 함수
    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Resources/MyCharacterList.txt");
        MyCharacter_List = JsonConvert.DeserializeObject<List<Character>>(jdata);
    }
}


