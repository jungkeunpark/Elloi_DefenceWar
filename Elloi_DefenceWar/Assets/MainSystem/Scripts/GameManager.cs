using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� ���� ���
    public static GameManager instance;

    // ���α׷� ����� ������ ����
    public int playerGold = 10000;
    public int playerJuwel = 3000;
    public int playerLevel = 1;
    public int exp = 0;
    public string playerName = "�ְ��̳�������";

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

}
