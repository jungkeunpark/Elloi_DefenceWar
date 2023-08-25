using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GatchaPremium : MonoBehaviour
{
    public static GatchaPremium gatchaPremium;
    //���ӿ�����Ʈ (��í�ִϸ��̼� + ��í�������)�ֻ���
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
    public bool Premiumretry = false;
    public bool GotoLobby = false;

    //��í�ִϸ��̼��� ������ ���
    public Sprite compareto_Novice;
    public Sprite compareto_Expert;
    public Sprite compareto_Elite;
    public Sprite compareto_Master;
    public Sprite compareto_Hero;

    //������ �ֱ����� ��������� ���ӿ�����Ʈ ȣ��
    public Image NoviceImg;
    public Image ExpertImg;
    public Image EliteImg;
    public Image MasterImg;
    public Image HeroImg;
    public Image[] TenGatchaImg = default;
    public Image[] BonusTenGatchaImg = default;
    public int ticket = 0;

    public TMP_Text NoviceName;
    public TMP_Text ExpertName;
    public TMP_Text EliteName;
    public TMP_Text MasterName;
    public TMP_Text HeroName;
    private int PremiumJuwel = 200;
    private int TenTimePremiumJuwel = 2000;
    public TMP_Text[] TenGatchaNames = default;
    public TMP_Text[] BonusTenGatchaNames = default;

    public GameObject PremiumFailObject;
    public TMP_Text PremiumFail;
    public int[] Premium10times = new int[10];


    public List<int> Premiumbonusindex;
    public int premiumBonusMax = 50;
    public int PremiumBonus = 0;


    private void Awake()
    {
        gatchaPremium = this;
    }


    //�����̾���í��ư�� ������ ����
    public void PremiumGatcha()
    {
        //�κ� ����
        lobby.gameObject.SetActive(false);

        BeforeBuy.transform.GetChild(0).gameObject.SetActive(true);
        BeforeBuy.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void PremiumGatchaOneTime()
    {

        if (GameManager.instance.playerJuwel >= PremiumJuwel)
        {
            SoundManager.soundManager.PlaySE("Gatcha_BGM");
            GameManager.instance.playerJuwel -= PremiumJuwel;

            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(1).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button1Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
            PremiumBonus += 1;
            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue <= 62.995f)
            {
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        NoviceImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        NoviceName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 62.995f && randomValue <= 83.995f)
            {
                //�ͽ���Ʈ�� ��í�ִϸ��̼� Ȱ��ȭ
                Expert.transform.GetChild(0).gameObject.SetActive(true);
                //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                int index = UnityEngine.Random.Range(501, 520);
                // ������ �ε��� ã��
                for (int i = 0; i < GameManager.instance.AllCharacter_List.Count; i++)
                {
                    // ������ �ε��� ã��
                    if (GameManager.instance.AllCharacter_List[i].index == index.ToString())
                    {
                        // �̹��� �ҷ�����
                        Sprite tempSprite = GameManager.instance.characterCardPrefabs[i].transform.GetChild(2).GetComponent<Image>().sprite;

                        //�ش� �ε����� �ش��ϴ� �̸��� �ҷ���
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        ExpertImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        ExpertName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 83.995f && randomValue <= 97.245f)
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        EliteImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        EliteName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 97.245f && randomValue <= 99.995f)
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        MasterImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        MasterName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 99.995f && randomValue <= 100f)
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
                        string Name = GameManager.instance.AllCharacter_List[i].Name;

                        //��񽺵���� �̹����� ��������Ʈ�� ������ �̹��� ��������Ʈ ����
                        HeroImg.sprite = tempSprite;

                        //��񽺵���� �̸��� ������ �̸��� ����
                        HeroName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else
            {
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.FailToBuy();
            }
        }

    }

    public void PremiumGatchaTenTime()
    {

        if (GameManager.instance.playerJuwel >= TenTimePremiumJuwel)
        {
            SoundManager.soundManager.PlaySE("Gatcha_BGM");
            for (int i = 0; i < 7; i++)
            {
                ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.instance.playerJuwel -= TenTimePremiumJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
            PremiumBonus += 10;
            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                if (randomValue <= 62.995f)
                {
                    //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(601, 610);
                    Premium10times[a] = index;

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
                            TenGatchaImg[a].sprite = tempSprite;
                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;
                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 62.995f && randomValue <= 83.995f)
                {
                    //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(501, 520);
                    Premium10times[a] = index;
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
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 83.995f && randomValue <= 97.245f)
                {
                    //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(401, 440);
                    Premium10times[a] = index;
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
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 97.245f && randomValue <= 99.995f)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Premium10times[a] = index;
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
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
                else if (randomValue > 99.995f && randomValue <= 100f)
                {
                    //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Premium10times[a] = index;
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
                            TenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            TenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }


                int b = Mathf.Min(Premium10times);
                if (b >= 101 && b <= 114)
                {
                    Hero.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (301 <= b && b <= 360)
                {
                    Master.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (401 <= b && b <= 440)
                {
                    Elite.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (501 <= b && b <= 520)
                {
                    Expert.transform.GetChild(0).gameObject.SetActive(true);
                }
                else if (601 <= b && b <= 610)
                {
                    Novice.transform.GetChild(0).gameObject.SetActive(true);
                }
            }

            ScrollActivate.scrollActivate.press();
        }
        else
        {
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.FailToBuy();
        }
    }

    public void PremiumGatchaBonus()
    {
        
        

        if ((int)(PremiumBonus / premiumBonusMax) >= 1)
        {
            SoundManager.soundManager.PlaySE("Gatcha_BGM");
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
            ticket = (int)(PremiumBonus / premiumBonusMax);

            Master.transform.GetChild(0).gameObject.SetActive(true);
            if (ticket > 0 && ticket <= 9)
            {
                PremiumBonus -= ticket * 50;

                for (int i = 0; i < 7; i++)
                {
                    ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

                }
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus = true;
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
                for (int a = 0; a < ticket; a++)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Premiumbonusindex[a] = index;

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
                            BonusTenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            BonusTenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
            }
            else if(ticket >= 10)
            {
                PremiumBonus -= 500;

                for (int i = 0; i < 7; i++)
                {
                    ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

                }
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus = true;
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.PremiumButton = true;
                for (int a = 0; a < 10; a++)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Premiumbonusindex[a] = index;
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
                            BonusTenGatchaImg[a].sprite = tempSprite;

                            //��񽺵���� �̸��� ������ �̸��� ����
                            BonusTenGatchaNames[a].text = Name;

                            //ī�� ȹ��
                            GameManager.instance.MyCharacter(index);
                        }
                    }
                }
            }
            BonusScroll.Bonusscroll.press();
        }
    }


    //�����̾���í��ư�� �������·� �ִϸ��̼��� ������ �����ϴ� UI
    public void PremiumGatchaEnding()
    {
        //300ũ����Ż�� �ٽ� ��í�ϴ� �����̾���Ʈ���̹�ư Ȱ��ȭ
        GameButton.transform.GetChild(1).gameObject.SetActive(true);
        //�κ�� ���ư��� ��ư Ȱ��ȭ
        GameButton.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void PremiumTenGatchaEnding()
    {
        GameButton.transform.GetChild(5).gameObject.SetActive(true);
    }




}
