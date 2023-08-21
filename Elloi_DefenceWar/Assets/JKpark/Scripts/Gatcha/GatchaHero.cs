using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GatchaHero : MonoBehaviour
{
    LoadSceneGatchaPLAY loadSceneGatchaPLAY;
    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;

    public GameObject BeforeBuy;

    //���ӿ�����Ʈ(�κ�ε��ư��� ��ư�� ��í��Ŀ� ���� ��ư)
    public GameObject lobby;
    public GameObject GameButton;

    //��Ʈ����,�κ��ư �������� �ȴ������� Ȯ�ν�Ű�� true/false��
    public bool HeroRetry = false;
    public bool GotoLobby = false;


    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;

    public Image NoviceImg;
    public Image ExpertImg;
    public Image EliteImg;
    public Image MasterImg;
    public Image HeroImg;
    public Image[] TenGatchaImg = default;

    public TMP_Text NoviceName;
    public TMP_Text ExpertName;
    public TMP_Text EliteName;
    public TMP_Text MasterName;
    public TMP_Text HeroName;
    public TMP_Text[] TenGatchaNames = default;
    private int HeroJuwel = 600;

    public GameObject HeroFailObject;
    public TMP_Text HeroFail;

    public int[] Hero10times = default;

    public void HeroGatcha()
    {
        //�κ� ����
        lobby.gameObject.SetActive(false);

        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void HeroGatchaOneTime()
    {
        if (GameManager.instance.playerJuwel >= HeroJuwel)
        {
            GameManager.instance.playerJuwel -= HeroJuwel;

            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue < 29.45f)
            {
                //����� ��í�ִϸ��̼� Ȱ��ȭ
                Novice.transform.GetChild(0).gameObject.SetActive(true);
                //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(601, 610);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        NoviceImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        NoviceName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 29.45f && randomValue < 43.45f)
            {
                //�ͽ���Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(501, 521);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        ExpertImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        ExpertName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 43.45f && randomValue < 74.5f)
            {
                //����Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                Elite.transform.GetChild(0).gameObject.SetActive(true);
                //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(401, 440);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        EliteImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        EliteName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 74.5f && randomValue < 95f)
            {
                //�������� ��í�ִϸ��̼� Ȱ��ȭ
                Master.transform.GetChild(0).gameObject.SetActive(true);
                //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(301, 360);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        MasterImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        MasterName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 95f && randomValue < 100f)
            {
                //������� ��í�ִϸ��̼� Ȱ��ȭ
                Hero.transform.GetChild(0).gameObject.SetActive(true);
                //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(101, 114);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        String Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        HeroImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        HeroName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
        }
        else
        {
            loadSceneGatchaPLAY.FailToBuy();
        }

    }

    public void HeroGatchaTenTime()
    {
        if (GameManager.instance.playerJuwel >= 10 * HeroJuwel)
        {
            GameManager.instance.playerJuwel -= 10 * HeroJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);


            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
                if(randomValue< 29.45f)
                {
                    //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(601, 610);
                    Hero10times[a] = index;
                }
                else if (randomValue > 29.45f && randomValue < 43.45f)
                {
                    //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(501, 521);
                    Hero10times[a] = index;
                }
                else if (randomValue > 43.45f && randomValue < 74.5f)
                {
                    //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(401, 440);
                    Hero10times[a] = index;

                }
                else if (randomValue > 74.5f && randomValue < 95f)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Hero10times[a] = index;

                }
                else if (randomValue > 95f && randomValue < 100f)
                {
                    //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Hero10times[a] = index;
                }

                int b = Mathf.Min(Hero10times);
                if (b > 101 && b < 114)
                {
                    Hero.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (301 < b && b < 360)
                {
                    Master.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (401 < b && b < 440)
                {
                    Elite.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (501 < b && b < 521)
                {
                    Expert.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (601 < b && b < 610)
                {
                    Novice.transform.GetChild(0).gameObject.SetActive(true);
                }

            }
        }
        else
        {
            loadSceneGatchaPLAY.FailToBuy();
        }
    }



    //����ΰ�í��ư�� �������·� �ִϸ��̼��� ������ �����ϴ� UI
    public void HeroGatchaEnding()
    {
        //600ũ����Ż�� �ٽ� ��í�ϴ� ����θ�Ʈ���̹�ư Ȱ��ȭ
        GameButton.transform.GetChild(2).gameObject.SetActive(true);
        //�κ�� ���ư��� ��ư Ȱ��ȭ
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void HeroTenthGatchaEnding()
    {
        GameButton.transform.GetChild(6).gameObject.SetActive(true);
    }
}
