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
    public Character (string _index, string _Rank, string _Name, string _Health, string _Damage, string _Defense, 
        string _AttackSpeed, string _MoveSpeed, string _ResponeCoolTime, string _Cost, bool _isGet)
    { index = _index; Rank = _Rank; Name = _Name; Health = _Health; Damage = _Damage; Defense = _Defense; 
        AttackSpeed = _AttackSpeed; MoveSpeed = _MoveSpeed; ResponeCoolTime = _ResponeCoolTime; Cost = _Cost; isGet = _isGet; }

    public string index, Rank, Name, Health, Damage, Defense, AttackSpeed, MoveSpeed, ResponeCoolTime, Cost;
    public bool isGet;
}

public class GameManager : MonoBehaviour
{
    // �̱��� ���� ���
    public static GameManager instance;

    // ��Ƽ ���� ������
    public GameObject[] curPartySetPrefabs = new GameObject[4];
    public GameObject[] characterCardPrefabs;

    // ���α׷� ����� ������ ����

    // UI ������
    public int playerGold = 10000;
    public int playerJuwel = 3000;
    public int playerLevel = 1;
    public int exp = 0;
    public string playerName = "�ְ��̳�������";

    // ��Ƽ ���� �� ĳ���� ī��
    public GameObject[] partySetCard = new GameObject[4];
    public int[] partySetCardIndex = new int[4] { -1, -1, -1, -1 };

    // ���� ������
    public TextAsset CharacterDatabase; // ĳ���� ������
    public List<Character> AllCharacter_List, MyCharacter_List, CurCharacter_List;

    // ������ ����
    public int doubleSpeedCount = 30;
    public int autoItemCount = 30;

    // ���� �������� �������� �ε���
    public int nowStageIndex;

    // ĳ���� �ε��� �ѹ� ������ ����
    public int characterIndex;

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
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void Start()
    {
        // ��ü ĳ���� ����Ʈ �ҷ�����
        string[] line = CharacterDatabase.text.Substring(0, CharacterDatabase.text.Length -1).Split('\n');

        // print(line.Length); // �� ������ test
        for (int i = 0; i < line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            // �⺻������ false�� �ʱ�ȭ
            char firstChar = row[10].Trim().ToUpper()[0];  // row[10]�� ù ��° ���ڸ� �빮�ڷ� ��ȯ
            bool tempRow = (firstChar == 'T');  // ù ��° ���ڰ� 'T'�̸� true, 'F'�̸� false

            AllCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], tempRow));

            if (tempRow)  // tempRow�� true�̸�
            {
                MyCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], tempRow));
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
        Debug.Log("ĳ����ī�忡 �ִ� ��..");
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
        if (sameCard != 0) { Debug.Log("�ߺ��Ǿ����ϴ�.");  return; }

        // �ߺ������ʾҴٸ�
        else if(sameCard == 0)
        {
            Debug.Log("�ߺ������ʾҽ��ϴ�.");

            // ��ü ĳ���� ī�忡�� �ε����� ���� ī���� ���� ��������
            for (int i = 0 ; i < AllCharacter_List.Count ; i++)
            {
                if (AllCharacter_List[i].index == characterIndex.ToString())
                {
                    MyCharacter_List.Add(new Character(
                    AllCharacter_List[i].index, AllCharacter_List[i].Rank, AllCharacter_List[i].Name,
                    AllCharacter_List[i].Health, AllCharacter_List[i].Damage, AllCharacter_List[i].Defense,
                    AllCharacter_List[i].AttackSpeed, AllCharacter_List[i].MoveSpeed, AllCharacter_List[i].ResponeCoolTime,
                    AllCharacter_List[i].Cost, true));

                    return;
                }
            }
        }
    }
}


