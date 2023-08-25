using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using UnityEditor;

[System.Serializable]
public class Character
{
    public Character(string _index, string _Rank, string _Name, string _type, string _Health, string _Damage, string _Defense,
        string _AttackSpeed, string _MoveSpeed, string _ResponeCoolTime, string _Cost, bool _isGet)
    {
        index = _index; Rank = _Rank; Name = _Name; type = _type; Health = _Health; Damage = _Damage; Defense = _Defense;
        AttackSpeed = _AttackSpeed; MoveSpeed = _MoveSpeed; ResponeCoolTime = _ResponeCoolTime; Cost = _Cost; isGet = _isGet;
    }

    public string index, Rank, Name, type, Health, Damage, Defense, AttackSpeed, MoveSpeed, ResponeCoolTime, Cost;
    public bool isGet;
}

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴 사용
    public static GameManager instance;

    // 다음 씬 이름
    public string nextScene;

    // 파티 구성 프리팹
    public GameObject[] curPartySetPrefabs = new GameObject[4];
    public GameObject[] characterCardPrefabs;

    // 프로그램 실행시 유지할 값들

    // UI 데이터
    public int playerGold = 10000;
    public int playerJuwel = 3000;
    public int playerLevel = 1;
    public int curExp = 0;
    public string playerName = "최강미남박정근";

    // 레벨업에 필요한 경험치
    public int[] needLevelUpExp = new int[20] { 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100, 2200, 2300, 2400 };

    // 파티 구성 된 캐릭터 카드
    public GameObject[] partySetCard = new GameObject[6];
    public int[] partySetCardIndex = new int[6] { -1, -1, -1, -1, -1, -1 };

    // 게임 데이터
    public TextAsset CharacterDatabase; // 캐릭터 데이터
    public List<Character> AllCharacter_List, MyCharacter_List, CurCharacter_List;

    // 아이템 갯수
    public int doubleSpeedCount = 30;
    public int autoItemCount = 30;

    // 현재 진행중인 스테이지 인덱스
    public int nowStageIndex;

    // 클리어한 스테이지
    public List<int> clearStageIndex = new List<int> { default };

    // 캐릭터 인덱스 넘버 저장할 변수
    public int characterIndex;

    // 내가 가진 카드
    public List<int> myGetCardsNumbers;

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
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        // 전체 캐릭터 리스트 불러오기
        string[] line = CharacterDatabase.text.Substring(0, CharacterDatabase.text.Length - 1).Split('\n');

        // print(line.Length); // 잘 들어갔는지 test
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            // 기본적으로 false로 초기화
            char firstChar = row[11].Trim().ToUpper()[0];  // row[10]의 첫 번째 글자를 대문자로 변환
            bool tempRow = (firstChar == 'T');  // 첫 번째 글자가 'T'이면 true, 'F'이면 false

            AllCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], tempRow));

            if (tempRow)  // tempRow가 true이면
            {
                MyCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], tempRow));

                myGetCardsNumbers.Add(i);

            }
        }

        // 내 캐릭터 리스트 불러오기
        //Load();
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

    // 내 캐릭터 리스트에 획득한 캐릭터만 추가하는 함수
    public void MyCharacter(int characterIndex)
    {
        int sameCard = 0;

        // 중복체크
        for (int i = 0; i < MyCharacter_List.Count; i++)
        {
            if (MyCharacter_List[i].index == characterIndex.ToString())
            {
                sameCard++;
            }
        }

        // 중복되었다면

        if (sameCard != 0) {   return; }

        // 중복되지않았다면
        else if(sameCard == 0)

        if (sameCard != 0) {  return; }

        // 중복되지않았다면
        else if (sameCard == 0)

        {

            // 전체 캐릭터 카드에서 인덱스가 같은 카드의 정보 가져오기
            for (int i = 0; i < AllCharacter_List.Count; i++)

            {
                if (AllCharacter_List[i].index == characterIndex.ToString())
                {
                    MyCharacter_List.Add(new Character(
                    AllCharacter_List[i].index, AllCharacter_List[i].Rank, AllCharacter_List[i].Name, AllCharacter_List[i].type,
                    AllCharacter_List[i].Health, AllCharacter_List[i].Damage, AllCharacter_List[i].Defense,
                    AllCharacter_List[i].AttackSpeed, AllCharacter_List[i].MoveSpeed, AllCharacter_List[i].ResponeCoolTime,
                    AllCharacter_List[i].Cost, true));

                    myGetCardsNumbers.Add(i);

                    return;
                }
            }
        }
    }
}

