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
    // �̱��� ���� ���
    public static GameManager instance;

    // ���� �� �̸�
    public string nextScene;

    // ��Ƽ ���� ������
    public GameObject[] curPartySetPrefabs = new GameObject[4];
    public GameObject[] characterCardPrefabs;

    // ���α׷� ����� ������ ����

    // UI ������
    public int playerGold = 10000;
    public int playerJuwel = 3000;
    public int playerLevel = 1;
    public int curExp = 0;
    public string playerName = "�ְ��̳�������";

    // �������� �ʿ��� ����ġ
    public int[] needLevelUpExp = new int[20] { 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100, 2200, 2300, 2400 };

    // ��Ƽ ���� �� ĳ���� ī��
    public GameObject[] partySetCard = new GameObject[6];
    public int[] partySetCardIndex = new int[6] { -1, -1, -1, -1, -1, -1 };

    // ���� ������
    public TextAsset CharacterDatabase; // ĳ���� ������
    public List<Character> AllCharacter_List, MyCharacter_List, CurCharacter_List;

    // ������ ����
    public int doubleSpeedCount = 30;
    public int autoItemCount = 30;

    // ���� �������� �������� �ε���
    public int nowStageIndex;

    // Ŭ������ ��������
    public List<int> clearStageIndex = new List<int> { default };

    // ĳ���� �ε��� �ѹ� ������ ����
    public int characterIndex;

    // ���� ���� ī��
    public List<int> myGetCardsNumbers;

    private void Awake()
    {
        // �����ϰ� ���� �ʴٸ� �ٽ� �ֽ�ȭ
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ����� �ı�X
        }
        else
        {
            // �ߺ����� �����Ѵٸ� �ı�
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        // ��ü ĳ���� ����Ʈ �ҷ�����
        string[] line = CharacterDatabase.text.Substring(0, CharacterDatabase.text.Length - 1).Split('\n');

        // print(line.Length); // �� ������ test
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            // �⺻������ false�� �ʱ�ȭ
            char firstChar = row[11].Trim().ToUpper()[0];  // row[10]�� ù ��° ���ڸ� �빮�ڷ� ��ȯ
            bool tempRow = (firstChar == 'T');  // ù ��° ���ڰ� 'T'�̸� true, 'F'�̸� false

            AllCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], tempRow));

            if (tempRow)  // tempRow�� true�̸�
            {
                MyCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], tempRow));

                myGetCardsNumbers.Add(i);

            }
        }

        // �� ĳ���� ����Ʈ �ҷ�����
        //Load();
    }


    // JSON ������ �����ϴ� �Լ�
    void Save()
    {
        // JSON ����ϱ� (List�� String���� ����Ʈ ���ݴϴ�.)
        string jdata = JsonConvert.SerializeObject(AllCharacter_List);
        print(jdata);

        // �� ĳ���� ����Ʈ ����
        File.WriteAllText(Application.dataPath + "/Resources/MyCharacterList.txt", jdata);
    }

    // JSON ������ �ҷ����� �Լ�
    void Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "/Resources/MyCharacterList.txt");
        MyCharacter_List = JsonConvert.DeserializeObject<List<Character>>(jdata);
    }

    // �� ĳ���� ����Ʈ�� ȹ���� ĳ���͸� �߰��ϴ� �Լ�
    public void MyCharacter(int characterIndex)
    {
        int sameCard = 0;

        // �ߺ�üũ
        for (int i = 0; i < MyCharacter_List.Count; i++)
        {
            if (MyCharacter_List[i].index == characterIndex.ToString())
            {
                sameCard++;
            }
        }

        // �ߺ��Ǿ��ٸ�

        if (sameCard != 0) {   return; }

        // �ߺ������ʾҴٸ�
        else if(sameCard == 0)

        if (sameCard != 0) {  return; }

        // �ߺ������ʾҴٸ�
        else if (sameCard == 0)

        {

            // ��ü ĳ���� ī�忡�� �ε����� ���� ī���� ���� ��������
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

