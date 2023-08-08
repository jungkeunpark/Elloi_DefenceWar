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
    // �̱��� ���� ���
    public static GameManager instance;

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
            AllCharacter_List.Add(new Character(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9] == "TRUE"));
        }

        // �� ĳ���� ����Ʈ �ҷ�����
        Load();
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
}


