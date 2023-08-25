using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GatchaHero : MonoBehaviour
{
    public static GatchaHero gatchaHero;

    public GameObject Novice;
    public GameObject Expert;
    public GameObject Elite;
    public GameObject Master;
    public GameObject Hero;

    public GameObject BeforeBuy;

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
    public Image[] BonusTenGatchaImg = default;
    public int ticket;

    public TMP_Text NoviceName;
    public TMP_Text ExpertName;
    public TMP_Text EliteName;
    public TMP_Text MasterName;
    public TMP_Text HeroName;
    private int HeroJuwel = 600;
    private int TenTimeHeroJuwel = 6000;
    public TMP_Text[] TenGatchaNames = default;
    public TMP_Text[] BonusTenGatchaNames = default;

    public GameObject HeroFailObject;
    public TMP_Text HeroFail;
    public int[] Hero10times = new int[10];


    public List<int> Herobonusindex;
    public int HeroBonusMax = 100;
    public int HeroBonus = 100;


    private void Awake()
    {
        gatchaHero = this;
    }


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

            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(3).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button1Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton = true;
            HeroBonus += 1;
            //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
            float randomValue = UnityEngine.Random.Range(0, 100f);
            if (randomValue <= 60.4f)
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
            else if (randomValue > 60.4f && randomValue <= 74.4f)
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
            else if (randomValue > 74.4f && randomValue <= 89.45f)
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


                        EliteImg.sprite = tempSprite;


                        EliteName.text = Name;

                        //ī�� ȹ��
                        GameManager.instance.MyCharacter(index);
                    }
                }
            }
            else if (randomValue > 89.45f && randomValue <= 99.95f)
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
            else if (randomValue > 99.95f && randomValue <= 100f)
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
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.FailToBuy();
        }

    }

    public void HeroGatchaTenTime()
    {
        if (GameManager.instance.playerJuwel >= TenTimeHeroJuwel)
        {

            for (int i = 0; i < 7; i++)
            {
                ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

            }
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
            GameManager.instance.playerJuwel -= TenTimeHeroJuwel;
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(3).gameObject.SetActive(false);
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.Button10Time = true;
            LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton = true;
            HeroBonus += 10;
            for (int a = 0; a < 10; a++)
            {
                float randomValue = UnityEngine.Random.Range(0, 100f);
                //����Ȯ���� ������ Ȯ�������� �����//������//����Ʈ//�ͽ���Ʈ//�븻 ��ȯ
                if (randomValue <= 60.4f)
                {
                    //��񽺵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(601, 610);
                    Hero10times[a] = index;

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
                else if (randomValue > 60.4f && randomValue <= 74.4f)
                {
                    //�ͽ���Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(501, 520);
                    Hero10times[a] = index;
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
                else if (randomValue > 74.4f && randomValue <= 89.45f)
                {
                    //����Ʈ����� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(401, 440);
                    Hero10times[a] = index;
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
                else if (randomValue > 89.45f && randomValue <= 99.95f)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Hero10times[a] = index;
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
                else if (randomValue > 99.95f && randomValue <= 100f)
                {
                    //����ε���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Hero10times[a] = index;
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

                int b = Mathf.Min(Hero10times);
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

    public void HeroGatchaBonus()
    {
        if ((int)(HeroBonus / HeroBonusMax) >= 1)
        {
            
            BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
            BeforeBuy.transform.GetChild(3).gameObject.SetActive(false);
            ticket = (int)(HeroBonus / HeroBonusMax);

            Hero.transform.GetChild(0).gameObject.SetActive(true);
            if (ticket > 0 && ticket <= 9)
            {
                HeroBonus -= ticket * 100;

                for (int i = 0; i < 9; i++)
                {
                    ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

                }
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus = true;
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton = true;
                for (int a = 0; a < ticket; a++)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(101, 114);
                    Herobonusindex[a] = index;
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
            else if (ticket >= 10)
            {
                HeroBonus -= 1000;
                for (int i = 0; i < 7; i++)
                {
                    ScrollActivate.scrollActivate.commonbuttonui.transform.GetChild(i).gameObject.SetActive(false);

                }
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.TenTimesGatcha.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(0).gameObject.SetActive(false);
                BeforeBuy.transform.GetChild(2).gameObject.SetActive(false);
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.ButtonBonus = true;
                LoadSceneGatchaPLAY.loadSceneGatchaPlay.HeroButton = true;

                for (int a = 0; a < 10; a++)
                {
                    //�����͵���� ��� �ε�����ȣ�߿� �Ѱ��� ����
                    int index = UnityEngine.Random.Range(301, 360);
                    Herobonusindex[a] = index;
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
